$.validator.unobtrusive.adapters.addBool("mustbetrue", "required");

$(document).ready(function () {

    $('.clickableRow').click(function () {        
        //console.log(1);
        $("#Modalid").modal();
        var id = $(this).closest('tr').attr('data-id');
        //console.log(id);
        var sData = JSON.stringify(id);
        $.ajax({
            url: '/Partner/AjaxMethod',
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            data: '{ id: "' + id + '" }',
            dataType: 'Json',
            success: function (data) {
                var FullName = data.FirstName + " " + data.LastName;
                $('.modal-title').append(FullName);
                $('#FirstName').empty().append("First name: " + data.FirstName);
                $('#LastName').empty().append("Last name: " + data.LastName);
                $('#Address').empty().append("Address: " + data.Address);
                $('#CreateByUser').empty().append("CreateByUser: " + data.CreateByUser);
                $('#CreatedAtUtc').empty().append("CreatedAtUtc: " + parseJsonDate(data.CreatedAtUtc));
                $('#CroatianPIN').empty().append("CroatianPIN: " + data.CroatianPIN);
                $('#ExternalCode').empty().append("ExternalCode: " + data.ExternalCode);
                $('#Gender').empty().append("Gender: " + data.Gender);
                $('#IsForeign').empty().append("IsForeign: " + data.IsForeign);
                $('#PartnerNumber').empty().append("PartnerNumber: " + data.PartnerNumber);
                $('#PartnerTypeId').empty().append("PartnerTypeId: " + data.PartnerTypeId == 1 ? "Personal" : "Legal");
            },
        });
    });

});


function parseJsonDate(jsonDateString) {
    return moment(jsonDateString).format("DD.MM.yyyy.").toUpperCase();
}