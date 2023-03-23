$(document).ready(function () {
    const searchParams = new URLSearchParams(window.location.search);
    var id = searchParams.get("parameter");
    if (id) {
        $("#territoriesList").val(id);
        GetShippers(id);
    }
    $("#territoriesList").change(function () {

        const selectedValue = $(this).val();
        if (selectedValue != -1) {
            GetShippers(selectedValue);
        } else {
            $("#idTerritories").val("");
            $("#description").val("");
            $("#region").val("");
        }
    });
});
function GetShippers(id) {
    $.ajax({
        url: '/Territories/GetByID?id=' + id,
        type: 'GET',
        success: function (result) {
            $("#idTerritories").val(result.ID);
            $("#description").val(result.Description);
            $("#region").val(result.RegionID);
        }
    });
}
