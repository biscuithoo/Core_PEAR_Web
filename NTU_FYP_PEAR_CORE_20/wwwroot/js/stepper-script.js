/*jslint browser: true*/
/*global $, jQuery, alert*/
includeJs("~/Content/global/scripts/inputChecks.js");


(function ($) {
    'use strict';

    $(function () {

        $(document).ready(function () {
            function triggerClick(elem) {
                $(elem).click();
            }
            var $progressWizard = $('.stepper'),
                $tab_active,
                $tab_prev,
                $tab_next,
                $btn_prev = $progressWizard.find('.prev-step'),
                $btn_next = $progressWizard.find('.next-step'),
                $tab_toggle = $progressWizard.find('[data-toggle="tab"]'),
                $tooltips = $progressWizard.find('[data-toggle="tab"][title]');

            // To do:
            // Disable User select drop-down after first step.
            // Add support for payment type switching.

            //Initialize tooltips
            $tooltips.tooltip();

            //Wizard
            $tab_toggle.on('show.bs.tab', function (e) {
                var $target = $(e.target);

                if ($(".form-group").hasClass("has-error") == true) {
                    e.preventDefault();
                    return false;
                }

                if ($target.parent().hasClass('disabled')) {
                    e.preventDefault();
                    return false;
                }

                if (!$target.parent().hasClass('active, disabled')) {
                    $target.parent().prev().addClass('completed');
                }

            });

            //$tab_toggle.on('click', function(event) {
            //    event.preventDefault();
            //    event.stopPropagation();
            //    return false;
            //});

            $btn_next.on('click', function () {
                var curStep = $(this).closest(".tab-pane");

                $tab_active = $progressWizard.find('.active');

                var curInputs = curStep.find("input[type='text'],input[type='url'],select");
                var isValid = true;

                $(".form-group").removeClass("has-error");

                for (var i = 0; i < curInputs.length; i++) {


                    if ($(curInputs[i]).attr("id") == "NRIC") {
                        var nric = $(curInputs[i]).val();
                        var type = $(curInputs[i]).attr("xtype");

                        if (!nric.trim() == "") {

                            if (!nricValidation(nric, type)) {
                                isValid = false;
                                $(curInputs[i]).closest(".form-group").addClass("has-error");
                            }
                        }

                    }

                    //Check if rs is others for guardian 1
                    if ($(curInputs[i]).attr("id") == "rsCheck") {
                        var val = document.getElementById('rsCheck').value;
                        if (val == -1) {

                            if (document.getElementById('othersg').value == "") {
                                isValid = false;
                                $(curInputs[i]).closest(".form-group").addClass("has-error");
                            }
                        }

                    }
                    if ($(curInputs[i]).attr("id") == "NRICg") {
                        var nric = $(curInputs[i]).val();
                        var type = $(curInputs[i]).attr("xtype");

                        if (!nric.trim() == "") {

                            if (!nricValidation(nric.trim(), type) || !guardianNricCheck()) {

                                isValid = false;
                                $(curInputs[i]).closest(".form-group").addClass("has-error");

                            }
                        }

                    }

                    //Check D0B
                    if ($(curInputs[i]).attr("dateDOB") == "dateDOB") {

                        if (!dateCheckaddPatient()) {
                            isValid = false;
                            $(curInputs[i]).closest(".form-group").addClass("has-error");
                        }
                    }

                    //Check date join
                    if ($(curInputs[i]).attr("dateJoin") == "dateJoin") {

                        if (!dateCheckaddPatient()) {
                            isValid = false;
                            $(curInputs[i]).closest(".form-group").addClass("has-error");
                        }
                    }

                    //Check dementia type
                    if ($(curInputs[i]).is('select') && $(curInputs[i]).attr("dementiaCheck") == "dementiaCheck") {

                        var dementiaList = $("#dementiaCheck").val();

                        if (!dementiaCheck() && dementiaList == null) {
                            isValid = false;
                            $(curInputs[i]).closest(".form-group").addClass("has-error");
                        }

                    }

                    //Check if guardian 2 details is filled
                    if ($(curInputs[i]).attr("id") == "NRICg2") {
                        var nric = $(curInputs[i]).val();
                        var type = $(curInputs[i]).attr("xtype");

                        var name = $("#nameg2").val();
                        var contact = $("#contactNog2").val();
                        var email = $("#emailg2").val();

                        if ((name != "" || contact != "" || email != "") && nric.trim() == "") {
                            isValid = false;
                            $(curInputs[i]).closest(".form-group").addClass("has-error");
                        }else if (!nric.trim() == "") {

                            if (!nricValidation(nric.trim(), type) || !guardianNricCheck()) {

                                isValid = false;
                                $(curInputs[i]).closest(".form-group").addClass("has-error");

                            }
                        }

                        

                    }

                    if ($(curInputs[i]).attr("id") == "rs2Check") {
                        var othersval = $("#othersg2").val();

                        var val = document.getElementById('rs2Check').value;

                        if (val == -1) {

                            if (othersval == "" && name != "" || contact != "" || email != "") {
                                isValid = false;
                                $(curInputs[i]).closest(".form-group").addClass("has-error");
                            }
                        }
                    }

                    if ($(curInputs[i]).attr("id") == "homeNo") {

                        var homeNo = $("#homeNo").val();

                        if (!homeNo.trim() == "" && !contactNoCheck(homeNo,"homeNo")) {
                            isValid = false;
                            $(curInputs[i]).closest(".form-group").addClass("has-error");
                        }
                    }

                    if ($(curInputs[i]).attr("id") == "contactNog2") {

                        var contactNog2 = $("#contactNog2").val();

                        if (!contactNog2.trim() == "" && !contactNoCheck(contactNog2, "contactNog2")) {
                            isValid = false;
                            $(curInputs[i]).closest(".form-group").addClass("has-error");
                        }
                    }

                    if ($(curInputs[i]).attr("id") == "contactNog") {

                        var contactNog = $("#contactNog").val();

                        if (!contactNog.trim() == "" && !contactNoCheck(contactNog, "contactNog")) {
                            isValid = false;
                            $(curInputs[i]).closest(".form-group").addClass("has-error");
                        }
                    }

                    if ($(curInputs[i]).attr("id") == "contactNo") {

                        var contactNo = $("#contactNo").val();

                        if (!contactNo.trim() == "" && !contactNoCheck(contactNo, "contactNo")) {
                            isValid = false;
                            $(curInputs[i]).closest(".form-group").addClass("has-error");
                        }
                    }

                    if ($(curInputs[i]).attr("id") == "emailg") {

                        var emailg = $("#emailg").val();

                        if (!emailg.trim() == "" && !emailCheck(emailg, "emailg")) {
                            isValid = false;
                            $(curInputs[i]).closest(".form-group").addClass("has-error");
                        }
                    }
                    if ($(curInputs[i]).attr("id") == "emailg2") {

                        var emailg2 = $("#emailg2").val();

                        if (!emailg2.trim() == "" && !emailCheck(emailg2, "emailg2")) {
                            isValid = false;
                            $(curInputs[i]).closest(".form-group").addClass("has-error");
                        }
                    }


                    if ($(curInputs[i]).attr("id") == "nameg2") {

                        var name = $("#nameg2").val();
                        var contact = $("#contactNog2").val();
                        var email = $("#emailg2").val();

                        if (name.trim() == "" && (contact != "" || email != "" || $("#NRICg2").val().trim() != "")) {
                            isValid = false;
                            $(curInputs[i]).closest(".form-group").addClass("has-error");
                        }
                    }

                    if ($(curInputs[i]).attr("id") == "contactNog2") {
                        var name = $("#nameg2").val().trim();
                        var contact = $("#contactNog2").val();
                        var email = $("#emailg2").val();

                        if (contact.trim() == "" && (name != "" || email != "" || $("#NRICg2").val().trim() != "")) {
                            isValid = false;
                            $(curInputs[i]).closest(".form-group").addClass("has-error");
                        }
                    }

                    if ($(curInputs[i]).attr("id") == "emailg2") {
                        var name = $("#nameg2").val().trim();
                        var contact = $("#contactNog2").val();
                        var email = $("#emailg2").val();

                        if (email.trim() == "" && (name != "" || contact != "" || $("#NRICg2").val().trim() != "" )) {
                            isValid = false;
                            $(curInputs[i]).closest(".form-group").addClass("has-error");
                        }
                    }

                    if (!curInputs[i].validity.valid) {
                        isValid = false;
                        $(curInputs[i]).closest(".form-group").addClass("has-error");
                    }


                }

                if (isValid) {

                    $tab_active.next().removeClass('disabled');

                    $tab_next = $tab_active.next().find('a[data-toggle="tab"]');

                    if (!$tab_active.parent().hasClass('active, disabled')) {
                        $tab_active.parent().prev().addClass('completed');


                    }

                    triggerClick($tab_next);
                }

            });

            $btn_prev.click(function () {
                $tab_active = $progressWizard.find('.active');
                $tab_prev = $tab_active.prev().find('a[data-toggle="tab"]');
                triggerClick($tab_prev);
            });
        });
    });

}(jQuery, this));


function includeJs(jsFilePath) {
    var js = document.createElement("script");

    js.type = "text/javascript";
    js.src = jsFilePath;

    document.body.appendChild(js);
}
