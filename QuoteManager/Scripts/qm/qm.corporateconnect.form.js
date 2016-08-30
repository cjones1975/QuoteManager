/* CORPORATE CONNECT
-----------------------------------------------------------------------*/

function EditSite() {
	
var grid = $("#CorporateConnectGrid").data("kendoGrid");
var row = grid.dataItem(grid.select());
if(row){
	id = row.corporateConnectId;
} else {
id = null;
}
grid.dataSource.read();
}