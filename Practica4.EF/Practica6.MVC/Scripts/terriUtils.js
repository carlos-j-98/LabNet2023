import { GetAll,GetNextId } from './getData.js'

$(document).ready(function () {
    const searchParams = new URLSearchParams(window.location.search);
    let id = searchParams.get("parameter");
    if (id) {
        $("#territoriesList").val(id);
        GetAll(id, "Territories").then(function (result) {
            SetIdValues(result);
        })
    } else {
        SetDefaultValues();
    }
    $("#territoriesList").change(function () {
        const selectedValue = $(this).val();
        if (selectedValue != -1) {
            GetAll(selectedValue, "Territories").then(function (result) {
                SetIdValues(result);
            });
        } else {
            SetDefaultValues();
        }
    });
});

function SetIdValues(result) {
    $("#idTerritories").val(result.ID);
    $("#description").val(result.Description);
    $("#region").val(result.RegionID);
}

function SetDefaultValues() {
    GetNextId("Territories").then(function (result) {

        $("#idTerritories").val(result);
    })
    $("#description").val("");
    $("#region").val("");
}

$("#description").keyup(function () {
    console.log($('#description').val());
    if ($('#description').val() === '') {
        $('#descriptionTerritoriesError').text('El campo no puede estar vacío');
    } else {
        $('#descriptionTerritoriesError').text('');
    }
})

$('#btnAdd, #btnDel').on('click', function () {
    if ($('#idTerritories').val() === '') {
        $('#idTerritoriesError').text('El campo no puede estar vacío');
        return false;
    }
    if ($('#description').val() === '') {
        $('#descriptionTerritoriesError').text('El campo no puede estar vacío');
        return false;
    }
    let btnValue = $(this).val();
    $("form").attr("action", "/Territories/Modify?request=" + btnValue);
    $("form").submit();
});