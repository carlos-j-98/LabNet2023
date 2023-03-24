export function GetAll(id,controller) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            url: `/${controller}/GetByID?id=` + id,
            type: 'GET',
            success: function (result) {
                resolve(result);
            }
        });
    })
}

export function GetNextId(controller) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            url: `/${controller}/GetLastId`,
            type: 'GET',
            success: function (result) {
                resolve(result);
            }
        });
    });
}