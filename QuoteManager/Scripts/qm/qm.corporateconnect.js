/* CORPORATE CONNECT
------------------------------------------------------------------*/

// Store selected row Id
var id;


function importOBSData() {
    var scenarioId = $("#ScenarioId").val();
    alert(scenarioId);
    $.ajax({
        url: "/CorporateConnect/CallWebService",
        type: 'POST',
        dataType: 'json',
        cache: 'false',
        data: { scenarioId: scenarioId },
        success: function (data) {
        
    },
    })
}

function on_columnHide(){
	var grid = $("#CorporateConnectGrid").data("kendoGrid");
	grid.hideColumn(1);
}

// Load site form when selected
function onChange(e) {
    var currentDataItem = this.dataItem(this.select());
    if (currentDataItem !== null) {
        $.getJSON("/CorporateConnect/CorporateConnect_Select",
            {
                id: currentDataItem.corporateConnectId
            },
            function (data) {
                $("#corporateConnectId").val(data.corporateConnectId);
                $("#existingSite").prop("checked", data.existingSite);
                $("#routerName").val(data.routerName);
                $("#isp").prop("checked", data.isp);
                $("#ispPrimaryBandwidth").val(data.ispPrimaryBandwidth);
                $("#ispBackupBandwidth").val(data.ispBackupBandwidth);
                $("#satellite").val(data.satellite);
                $("#satelliteBackupBandwidth").val(data.satelliteBackupBandwidth);
                $("#serviceNet1Id").data("kendoDropDownList").value(data.serviceNet1Id);
                $("#serviceNet2Id").data("kendoDropDownList").value(data.serviceNet2Id);
                $("#serviceNet3Id").data("kendoDropDownList").value(data.serviceNet3Id);
                $('#sitaQuickStart').prop("checked", data.sitaQuickStart);
                $('#ispOTC').data("kendoNumericTextBox").value(data.ispOTC);
                $('#ispMRC').data("kendoNumericTextBox").value(data.ispMRC);
                $('#accessOTC').data("kendoNumericTextBox").value(data.accessOTC);
                $('#accessMRC').data("kendoNumericTextBox").value(data.accessMRC);
                $('#hardwareOTC').data("kendoNumericTextBox").value(data.hardwareOTC);
                $('#hardwareMRC').data("kendoNumericTextBox").value(data.hardwareMRC);
                $('#serviceMngtOTC').data("kendoNumericTextBox").value(data.serviceMngtOTC);
                $('#serviceMngtMRC').data("kendoNumericTextBox").value(data.serviceMngtMRC);
                $('#billable').data("kendoDropDownList").value(data.billable);
                $('#servcieMRPDiscountValue').val(data.servcieMRPDiscountValue);
            }
        );
    }
}

function onDataBound(e) {
    if (id) {
        var item = this.dataSource.get(id);
        this.select($(this.tbody).find("tr[data-uid='" + item.uid + "'"));
    }
}