$(document).ready(function () {

    $("#cpdRequiredForOtherCheck").change(function () {

        if ($(this).prop("checked")) {
            $(".diff_cpd_req").removeAttr("disabled");
            $(".diff_cpd_req").rules("add", "required");
        } else {

            $(".diff_cpd_req").val("");
            $(".diff_cpd_req").attr("disabled", true);
            $(".diff_cpd_req").rules("remove", "required");
            removeFieldValidationErrorDisplay(".diff_cpd_req");
        }

    });
    
    $('#CpdRequired').change(function () {
        if ($("#CpdRequired").val() == "NotRequired") {
            $("#star_error").hide();
            $("#cpd_reqired_for_error_text").hide();
            $(".cpdrequired_error").hide();
            $(".cpdrequired").attr("disabled", true);
            $(".cpdrequired").attr("checked", false);
        } else {
            $(".cpdrequired").removeAttr("disabled");
            $(".cpdrequired").attr("checked", false);
            $("#cpd_reqired_for_error_text").show();
            $("#star_error").show();
        }
    });

    $('#toggleStatus').click(function(e) {
        var $e = $(e.target);
        if (!$e.attr("oid")) {
            $e = $e.closest("[oid]");
        }
        var id = $e.attr("oid");
        $.ajax({
            type: "POST",
            url: "/country/togglestatus",
            data: { id: id },
            success: function(rowData) {
                var node = stringFormat("tr[oid='{0}']", id);
                table.fnUpdate(rowData, node);
                $('#statusToggleModal').modal('toggle');
            },
            error: function(data) {
                // show error message
            }
        });
    });
    
    $("#cpdRequiredForOtherCheck").change(function () {
        if ($(this).prop("checked")) {
            $(".diff_cpd_req").removeAttr("disabled");
            $(".diff_cpd_req").rules("add", "required");
        } else {
           
            $(".diff_cpd_req").val("");
            $(".diff_cpd_req").attr("disabled", true);
            $(".diff_cpd_req").rules("remove", "required");
            removeFieldValidationErrorDisplay(".diff_cpd_req");
        }
    });
 
  $("#add2ndClub").click(function () {
        $("#club-container").append($("#clubFormTemplate").tmpl({ index: 1, primaryIndex: 0, secondaryIndex: 3 }));

        $("#ClubsNumber1")
          .on("keypress paste", function (e) {
              var thisEl = $(this);
              return numberValidate(thisEl.attr("id"), thisEl.val().length, thisEl.val(), e);
          })
          .on("focusout", function () {
              numberValidationCheck($(this));
          });

        $(this).remove();
  });

  
    $("#country_table tbody").on('click', '.actionable', function (e) {
        var id = this.dataset.countryId;
        $('#toggleStatus').attr({ oid: id });
        $("#statusToggleModal").modal({ backdrop: "static", keyboard: false });
    });
    $('#country_table_wrapper .dataTables_filter input').addClass("input-medium ");
    $('#country_table_wrapper .dataTables_length select').addClass("select2-wrapper span12");
    $(".select2-wrapper").select2({ minimumResultsForSearch: -1 });

});
    