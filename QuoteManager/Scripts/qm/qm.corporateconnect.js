function importData() {
    var scenarioId = $("#ScenarioId").data("kendoNumericTextBox").value();
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