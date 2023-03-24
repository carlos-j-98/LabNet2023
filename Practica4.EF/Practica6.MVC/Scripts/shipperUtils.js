import { GetAll, GetNextId } from './getData.js'

const controller = "Shippers";

$(document).ready(function () {
    const searchParams = new URLSearchParams(window.location.search);
    let id = searchParams.get("parameter");
    if (id) {
        $("#shipperList").val(id);
        GetAll(id, controller).then(function (result) {
            SetIdValues(result);
        });
    } else {
        SetDefaultValues();
    }
    $("#shipperList").change(function () {
        const selectedValue = $(this).val();
        if (selectedValue != -1) {
            GetAll(selectedValue, controller).then(function (result) {
                SetIdValues(result);
            });
        } else {
            SetDefaultValues();
        }
    });
});
function SetIdValues(result) {
    $("#idShipper").val(result.ID);
    $("#companyName").val(result.CompanyName);
    $("#phone").val(result.Phone);
}

function SetDefaultValues() {
    GetNextId(controller).then(function (result) {
        $("#idShipper").val(result);
    })
    $("#companyName").val("");
    $("#phone").val("");
}
$("#companyName").keyup(function () {
    if ($('#companyName').val() === '') {
        $('#companyNameError').text('El campo no puede estar vacío');
    } else {
        $('#companyNameError').text('');
    }
})

$('#btnAdd, #btnDel').on('click', function () {
    if ($('#idShipper').val() === '') {
        $('#idShipperError').text('El campo no puede estar vacío');
        return false;
    }
    if ($('#companyName').val() === '') {
        $('#companyNameError').text('El campo no puede estar vacío');
        return false;
    }
    let btnValue = $(this).val();
    $("form").attr("action", "/Shippers/Modify?request=" + btnValue);
    $("form").submit();
});
