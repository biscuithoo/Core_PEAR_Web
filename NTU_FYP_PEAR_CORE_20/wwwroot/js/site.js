// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {



    $('.nav__toggle').on('click', function () {
        $('.navClass, .mobile-mask').toggleClass('show');
    });

    $('.mobile-mask').on('click', function () {
        $('.navClass, .mobile-mask').removeClass('show');
    });


    $('.lsAccSettingsIcon').hover(
        function () { $(this).addClass('fa-spin') },
        function () { $(this).removeClass('fa-spin') }
    )

    $('[data-toggle="tooltip"]').tooltip();

});

function accountSearch() {
    var input = document.getElementById("filterInput");
    var filter = input.value.toUpperCase();
    var table = document.getElementById("accountsTable");
    var trParent = table.getElementsByClassName("parentAccount");
    var trChild = table.getElementsByClassName("childAccount");

    console.log(trParent);
    console.log(trChild);

    for (i = 0; i < trParent.length; i++) {
        var trChilderns = trParent[i].getElementsByTagName("td");

        for (j = 0; j < trChilderns.length; j++) {
            var td = trChilderns[j];
            if (td) {
                txtValue = td.textContent || td.innerText;
                console.log(txtValue);
                if (txtValue.toUpperCase().indexOf(filter) > -1) {
                    trParent[i].style.display = "";
                    trChild[i].style.display = "";
                    break;
                } else {
                    trParent[i].style.display = "none";
                    trChild[i].style.display = "none";
                }
            }
        }
    }



}


function confirmDelete(id, isDeletedClicked) {
    var deleteSpan = 'deleteSpan_' + id;
    var confirmDeleteSpan = 'confirmDeleteSpan_' + id;

    if (isDeletedClicked) {
        $('#' + deleteSpan).hide();
        $('#' + confirmDeleteSpan).show();
    } else {
        $('#' + deleteSpan).show();
        $('#' + confirmDeleteSpan).hide();
    }
}
