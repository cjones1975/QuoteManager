
/*GLOBAL PAGE VARIABLES
-------------------------------------------------------------------------------*/
var folderValue = parseInt(document.getElementById('selectedFolderId').value),
    quoteValue = parseInt(document.getElementById('selectedQuoteId').value),
    quotePage = parseInt(document.getElementById('selectedQuotePage').value);

function showPopup(popupTitle, httpType, popupUrl, popupData) {
    var popup = $("#Popup").data("kendoWindow");
    popup.title(popupTitle);
    popup.content("Loading content...");
    popup.refresh({ type: httpType, url: popupUrl, data: { id: popupData } });
    popup.center();
    popup.open();
}

function closePopup() {
    var win = $("#Popup").data("kendoWindow");
    win.close();
}

/* QUOTE FUNCTIONS */
function onQuoteMenu_Select(e) {
   //var contentUrl = "";
   //   $(e.item).children(".k-link").text().toUpperCase()
    var itemId = $(e.item).attr('id');
    var win = $("#Popup").data("kendoWindow");
    switch (itemId) {
        case "ADDQUOTE":
            showPopup("Create Quote", "GET", "/Quote/QuoteAdd", "");
            break;
        case "EDITQUOTE":
            var quoteGrid = $("#QuoteGrid").data("kendoGrid");
            var model = quoteGrid.dataItem(quoteGrid.select());
            var id = model.quoteId;
            showPopup("Edit Quote", "POST", "/Quote/QuoteEdit", id);
            //win.title("Edit Quote");
            //win.content("Loading content...");
            //win.refresh({
            //    type: "POST",
            //    url: "/Quote/QuoteEdit",
            //    data: { id: id }
            //});
            //win.center();
            //win.open();
            break;

    }

    

}

function getQuoteId() {
    var quoteGrid = $("#QuoteGrid").data("kendoGrid");
    var model = quoteGrid.dataItem(quoteGrid.select());
    return {
        quoteId: model.quoteId
    };
}

// Close form window and refresh folder and grid controls
function onQuote_Add(folderId){
    $('#QuoteFolder').data('kendoDropDownList').value(folderId);
    $('#QuoteFolder').data('kendoDropDownList').trigger('change');
    closePopup();
}

// Quote Add/Edit customer functions
function onCustomerName_Change() {
    var value = $("#customerId").data("kendoComboBox").value();
    $("#custId").data("kendoComboBox").value(value);
    $("#alphaCode").data("kendoComboBox").value(value);
    //if ($("#alphaCode").data("kendoComboBox").text().match("^#PR")) {
    //    $("#customerProspect").show();
    //} else {
    //    $("#customerProspect").hide();
    //}
}

function onCustomerId_Change() {
    var value = $("#custId").data("kendoComboBox").value();
    $("#customerId").data("kendoComboBox").value(value);
    $("#alphaCode").data("kendoComboBox").value(value);
}

function onAlphaCode_Change() {
    var value = $("#alphaCode").data("kendoComboBox").value();
    $("#customerId").data("kendoComboBox").value(value);
    $("#custId").data("kendoComboBox").value(value);
}

/* END QUOTE MENU FUNCTION */

/* FOLDER FUNCTIONS */
function onFolder_DataBound() {
    $('#QuoteFolder').data('kendoDropDownList').select(function (dataItem) {
        return dataItem.folderId === parseInt(folderValue);
    })
    var datasource = $('#QuoteGrid').data().kendoGrid.datasource;
    datasource.query({
        page: quotePage,
        pageSize: datasource.pageSize()
    })
}

function onFolder_Add() {
    $.ajax({
        url: "/Quote/FolderAdd",
        cache: false,
        type: "GET",
        dataType: "html",
        success: function (data) {
            $("#SECTION_FOLDERS").html(data);
        },
        error: function () {
            alert('error!');
        }
    });
}

function onFolder_Edit() {
    //Disable quote menus add?edit
    //("#Quotation_Menu").data("kendoMenu").enable("#EDITQUOTE", false);
    //$("#Quotation_Menu").data("kendoMenu").enable("#ADDQUOTE", false);
    $.ajax({
        url: "/Quote/FolderEdit",
        cache: false,
        type: "GET",
        data: { id: $("#QuoteFolder").data("kendoDropDownList").value() },
        success: function (data) {
            $('#SECTION_FOLDERS').html(data);
        }
    });
}

function onFolder_Delete() {
    var conf = confirm("Are you sure you want to delete this folder?");
    if (conf === true) {
        folderValue = 0;
        $.ajax({
            url: "FolderDelete",
            data: { id: $("#QuoteFolder").data("kendoDropDownList").value() },
            success: function (data) {
                if (data.success === true) {
                    $('#SECTION_FOLDERS').html(data.view);
                }
                else if (data.success === false) {
                    alert("Folders that contain quotes cannot be deleted.");
                }
            }
        });
    }
}

function onFolder_Save(result) {
    if (result.success === true) {
        folderValue = result.folderId;
        getFolderList();
    }
    else {
        $('#response').html(result.error);
        $('#response').show();
    }
}

function onFolder_Cancel() {
    getFolderList()
}

function getFolderList() {
    $.ajax({
        httpMethod: 'GET',
        url: "/Quote/FolderList",
        cache: false,
        dataType: 'html',
        success: function (data) {
            //load Folder list
            $('#SECTION_FOLDERS').html(data);
        }
    });
}

function onFolder_Change()
{
    quoteValue = 0;
    folderValue = $("#QuoteFolder").data("kendoDropDownList").value();
    $("#QuoteGrid").data("kendoGrid").dataSource.read();
}

function getFolderId() {
    value = $('#QuoteFolder').data('kendoDropDownList').value();
    return {
        Id: value
    };
}

/* END FOLDER FUNCTIONS */

/* QUOTE GRID FUNCTIONS */

function onQuoteGrid_Change(e) {
    //var quoteGrid = $("#QuoteGrid").data("kendoGrid");
    //var model = quoteGrid.dataItem(quoteGrid.select());

    //Service_Grid read data
    $('#ProductGrid').data('kendoGrid').dataSource.read();
    
}
    

function onQuoteGrid_DataBound(e) {
    //Check for grid data
    if (e.sender._data.length === 0) {
        //Send empty datasoruce to Service_Grid
        $("#ProductGrid").data("kendoGrid").dataSource.data([]);
        //Disable 'Quote' menu items
        //$("#Quotation_Menu").data("kendoMenu").enable("#EDITQUOTE", false);
        //Disable 'Service' menu item
        //$("#Service_Menu").data("kendoMenu").enable("#SERVICEACTIONS", false);
        //$("#Quotation_Menu").data("kendoMenu").enable("#DELETEQUOTE", false);
        //$("#Quotation_Menu").data("kendoMenu").enable("#DUPLICATEQUOTE", false);
    }
    else {
        //Enable 'Quote' menu item
        //$("#Quotation_Menu").data("kendoMenu").enable("#EDITQUOTE", true);
        //Enable 'Total Contract Value' menu item
        //Enable 'Service' menu item
       // $("#Service_Menu").data("kendoMenu").enable("#SERVICEACTIONS", true);
        //$("#Quotation_Menu").data("kendoMenu").enable("#DELETEQUOTE", true);
        //$("#Quotation_Menu").data("kendoMenu").enable("#DUPLICATEQUOTE", true);
        //Select first grid row
        var page = this.dataSource.page()
        if (page !== quotePage) {
            quoteValue = 0;
            quotePage = page;
        }
        var uid = 0;
        var row = null;
        if (quoteValue === 0) {
            row = $(this.tbody).find("tr:first");
        }
        else {
            var grid = this;
            $.each(this.tbody.find('tr'), function () {
                var model = grid.dataItem(this);
                if (model.quoteId === quoteValue) {
                    uid = model.uid
                }
            });
            row = $(this.tbody).find("tr[data-uid='" + uid + "']");
        }
        this.select(row);
    }
}

/* END QUOTE GRID FUNCTIONS

/* PRODUCT FUNCTIONS */

function onProductMenu_Select(e) {
    var id = $(e.item).attr('id');
   
    //var serviceGrid = $("#Service_Grid").data("kendoGrid");
    //var model = serviceGrid.dataItem(serviceGrid.select());
    switch (id) {
        case "ADDPRODUCT":
            var quoteGrid = $("#QuoteGrid").data("kendoGrid");
            showPopup("CIS Solution Line", "GET", "/Quote/ProductAdd", quoteGrid.dataItem(quoteGrid.select()).quoteId);
            break;
        case "DELETESERVICE":
            $('#ProductGrid').data('kendoGrid').dataSource.read();
            //var conf = confirm("Are you sure you want this service?");
            //if (conf === true) {
            //    var contentUrl = "ServiceDelete";
              //  $.ajax({
               //     url: contentUrl,
               //     data: { id: model.assignedserviceId }
               // });
            //}
            break;
    }
}

function filterProductGroup() {
    return {
        productFamilyId: $("#productFamilyId").val()
    };
}

function filterProduct() {
    return {
        productGroupId: $("#productGroupId").val()
    };
}

function onProductGrid_DataBound(e) {
    if (e.sender._data.length === 0) {
        //Disable menu items
        $("#Product_Menu").data("kendoMenu").enable("#DELETEPRODUCT", false);       
    }
    else {
        //Enable menu items
        $("#Product_Menu").data("kendoMenu").enable("#DELETEPRODUCT", true);
        var first = $(this.tbody).find("tr:first");
        this.select(first);
    }
}

function onOpen_Product() {

}

