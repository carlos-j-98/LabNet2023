$(document).ready(function () {
    const searchParams = new URLSearchParams(window.location.search);
    var id = searchParams.get("parameter");
    if (id) {
        $("#shipperList").val(id);
        GetShippers(id);
    }
    $("#shipperList").change(function () {
        
        const selectedValue = $(this).val();
        if (selectedValue != -1) {
            GetShippers(selectedValue);
        } else {
            $("#idShipper").val("");
            $("#companyName").val("");
            $("#phone").val("");
        }
    });
});
function GetShippers(id) {
    $.ajax({
        url: '/Shippers/GetByID?id='+id,
        type: 'GET',
        success: function (result) {
            $("#idShipper").val(result.ID);
            $("#companyName").val(result.CompanyName);
            $("#phone").val(result.Phone);
        }
    });
}
