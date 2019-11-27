/*
	jQuery Form Validators v0.3.5
	Website: http://validator.codeplex.com/
	License: http://validator.codeplex.com/license
	Examples:
    <input type='text' validate='group' require='please enter a value' />
	<input type='text' validate='group' email='invalid email' />
    <input type='text' validate='group' regular='must be less than 6 chars long' validExpress='.{6,}' />
	<input type='text' validate='group' regular='must be less than 6 chars long' invalidExpress='.{,6}' />
    <input type='text' validate='group' compare='password mismatch' compareTo='button1' />
    <input type='text' validate='group' custom='must be less than 6 chars long' customFn='this.length < 6' />
    <input type='text' validate='group' invalid='username cannot be used' invalidVal='username' />
    <input type='text' custom='Please Enter Val' validate='group' customFn='var age = parseInt(this.value); return age > 0;'/>
    <input type="button" onclick="if(validate('group')){showTab(3,&quot;next&quot;);}" value="Next" class="button" style="float:right;">
*/

function testPwd(elem) {
    //<input id="txtPwdRegexVal" type="text" value="((?=.*\d)(?=.*[A-Z])(?=.*[a-z]).{8,16})" style="display:none;"/>
    var val = $(elem).val();
    if (val.length <= 16) {
        var re = new RegExp($("#txtPwdRegexVal").val());
        if (val.match(re)) return true;
        else return false;
    }
    else {
        return false;
    }
}

var validate;

(function($) {
    validate = function(group) {
        var marker = true;
        $("*[validate=" + group + "]").each(function(i, elm) {
            if (check(elm)) {
                $(elm).highlight();
                if (marker)
                    $(elm).find(":input").andSelf().focus();
                marker = false;
            }
            else
                $(elm).unhighlight();
        });
        return marker;
    }

    function revalidate() {
        if (!check(this))
            $(this).unhighlight();
        else
            $(this).highlight();
    }

    function check(elm) {
        var jelm = $(elm);
        if (jelm != undefined && jelm != null && jelm.val() != "" && jelm.val() != null) {
            jelm.val(jelm.val().trim());
        }
        var listsize = jelm.find("input:radio, input:checkbox").size();
        if (jelm.attr("disabled") || listsize > 0 && listsize == jelm.find("input:radio:disabled, input:checkbox:disabled").size())
            return "";

        //if empty value only perform required validation
        if ((jelm.val() == "" || jelm.val() == null) && jelm.find("input:radio:checked, input:checkbox:checked").size() == 0)
            return jelm.attr("require") ? "require" : "";

        if (jelm.attr("regular") && jelm.attr("validExpress") && !new RegExp(jelm.attr("validExpress"), "m").test(jelm.val()))
            return "regular";

        if (jelm.attr("regular") && jelm.attr("invalidExpress") && new RegExp(jelm.attr("invalidExpress"), "m").test(jelm.val()))
            return "regular";

        if (jelm.attr("compare") && $("#" + jelm.attr("compareTo")).val() != jelm.val())
            return "compare";

        if (jelm.attr("custom") && !new Function(jelm.attr("customFn")).call(elm))
            return "custom";
        
        if (jelm.attr("datevalidator") && !dateValidator(jelm.val()))
            return "datevalidator";

        if (jelm.attr("invalid") && jelm.val() == jelm.attr("invalidVal"))
            return "invalid";

        if (validators != undefined) {
            for (var name in validators)
                if (jelm.attr(name) && !validators[name].call(elm))
                return name;
        }
    }

    //function showAlert() {
    //    var ctrl = $(this);

    //    //		var top = ctrl.offset().top + ctrl.height() + 4;
    //    //		var left = ctrl.offset().left + Math.max(ctrl.width() - 260, 0);

    //    var top = ctrl.offset().top + ctrl.height() - 30;
    //    var left = ctrl.offset().left; //+Math.max(ctrl.width(), 0);

    //    ctrl.parents().each(function() {
    //        if ($(this).css("position") != "static" && (!$.browser.mozilla || $(this).css("display") != "table")) {
    //            var offset = $(this).offset();
    //            top -= offset.top;
    //            left -= offset.left - 1;
    //            return false;
    //        }
    //    });
    //    ctrl.parent().children(".alertbox").remove();
    //    ctrl.parent().append("<span class='alertbox' title='" + ctrl.attr(check(this)) + "'></span>");
    //    //<div style='width:" + (ctrl.width() - 4) + "px;'>" + ctrl.attr(check(this)) + "</div></div>");
    //}

    //function hideAlert() {
    //    $(this).parent().children(".alertbox").remove();
    //}

    $.fn.highlight = function () {
        if (this.parent("div.form-group").length) {
            var frmgrp = this.parent(".form-group");
            if (!frmgrp.hasClass("has-feedback")) {
                frmgrp.addClass("has-feedback")
            }
            frmgrp.removeClass("has-error").removeClass("has-success").addClass("has-warning");
        }
        else {
            this.wrap($("<div/>", { class: "form-group has-error has-feedback" }));
        }

        var frmgrp = this.parent(".form-group");

        if (frmgrp.children("label").length) {
            var lbl = frmgrp.children("label");
            if (!lbl.hasClass("control-label")) {
                lbl.addClass("control-label");
            }            
        }
        if (!this.hasClass("form-control")) {
            this.addClass("form-control");
        }

        if (!this.hasClass("form-control")) {
            this.addClass("form-control");
        }

        var spn = frmgrp.children("span.glyphicon.form-control-feedback");

        if (spn.length) {
            spn.removeClass("glyphicon-ok").removeClass("glyphicon-warning-sign").removeClass("glyphicon-remove");
        }
        else {
            spn = $("<span/>", { class: "glyphicon form-control-feedback" })
            frmgrp.append(spn);
        }
        spn.attr("title", this.attr(check(this)));
        spn.addClass("glyphicon-warning-sign");
        spn.css("top",1);

        this.change(revalidate); return this;
    }

    $.fn.unhighlight = function () {
        if (this.parent("div.form-group").length) {
            var frmgrp = this.parent(".form-group");
            if (!frmgrp.hasClass("has-feedback")) {
                frmgrp.addClass("has-feedback");
            }
            frmgrp.removeClass("has-warning").removeClass("has-error").addClass("has-success");
        }
        else {
            this.wrap($("<div/>", { class: "form-group has-success has-feedback" }));
        }

        var frmgrp = this.parent(".form-group");

        if (frmgrp.children("label").length) {
            var lbl = frmgrp.children("label");
            if (!lbl.hasClass("control-label")) {
                lbl.addClass("control-label");
            }
        }
        if (!this.hasClass("form-control")) {
            this.addClass("form-control");
        }

        if (!this.hasClass("form-control")) {
            this.addClass("form-control");
        }

        var spn = frmgrp.children("span.glyphicon.form-control-feedback");

        if (spn.length) {
            spn.removeClass("glyphicon-ok").removeClass("glyphicon-warning-sign").removeClass("glyphicon-remove");
        }
        else {
            spn = $("<span/>", { class: "glyphicon form-control-feedback" });
            frmgrp.append(spn);
        }
        spn.attr("title", "");
        spn.addClass("glyphicon-ok");
        spn.css("top", 1);

        return this;       
    }

})(jQuery);

var validators = {
    "email": function () {
        var filter = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
        if (filter.test(this.value)) {
            return true;
        }
        else {
            return false;
        }
    }
};

var dateValidator = function(date){
    var startDate = Date.parse('1/1/1753'),endDate = Date.parse('12/31/9999'),enteredDate = Date.parse(date);
    var bits = date.split('/');
    var d = new Date(bits[2], bits[0] - 1, bits[1]);
    return (d && (d.getMonth() + 1) == bits[0] && d.getDate() == Number(bits[1])) && ((startDate <= enteredDate) && (enteredDate <= endDate));
}