
$(document).ready(txtbBeneficiaryAutocomplete);

var prm = Sys.WebForms.PageRequestManager.getInstance();

prm.add_endRequest(txtbBeneficiaryAutocomplete);

function txtbBeneficiaryAutocomplete() {
    $(function () {
        $('#cphMain_txtbBeneficiary').autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: 'UserHandler.ashx',
                    dataType: "json",
                    data: {
                        term: request.term
                    },
                    success: function (data) {
                        response($.map(data, function (item) {
                            return {
                                label: item.Name + ' - ' + item.Team,
                                val: item.Username
                            };
                        }));
                    },
                    error: function (response) {
                        alert(response.responseText);
                    },
                    failure: function (response) {
                        alert(response.responseText);
                    }
                });
            },
            select: function (event, ui) {
                $("#cphMain_hfUserUsername").val(ui.item.val);
            },
            minLength: 3
        });
    });
}