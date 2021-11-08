class Validator {

    validationSuccess
    form
    children

    constructor(form) {
        this.form = form;
        this.children = form.children;
    }

    setValidationErrorMessage(id, message) {
        for (var i = 0; i < this.children.length; i++) {
            var elem = this.children[i];
            if (elem.getAttribute("data-valmsg-for") == id) {
                elem.classList.replace("field-validation-valid", "field-validation-error");
                if (elem.getAttribute("data-valmsg-replace") == "true") {
                    elem.innerText = message;
                }
            }
        }
    }

    failValidation(elem, messageType) {
        this.validationSuccess = false;
        elem.classList.add("input-validation-error");
        this.setValidationErrorMessage(elem.id,
            elem.getAttribute(messageType));
    }

    refreshValidationElements() {
        for (var i = 0; i < this.children.length; i++) {
            var elem = this.children[i];
            elem.classList.remove("input-validation-error");
            elem.classList.replace("field-validation-error", "field-validation-valid");
        }
    }

    validate() {
        this.validationSuccess = true;
        this.refreshValidationElements();
        for (var i = 0; i < this.children.length; i++) {
            var elem = this.children[i];
            if (elem.getAttribute("data-val")) {
                //Существование значения поля(поле не пустое)
                if (elem.getAttribute("data-val-required")) {
                    if (elem.value == "") {
                        this.failValidation(elem, "data-val-required");
                        continue;
                    }
                }

                //Корректный email
                if (elem.getAttribute("data-val-email")) {
                    var regex = /^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$/;
                    if (!regex.test(elem.value)) {
                        this.failValidation(elem, "data-val-email");
                        continue;
                    }
                }

                //Соответствие регулярному выражению
                if (elem.getAttribute("data-val-regex")) {
                    var regex = new RegExp(elem.getAttribute("data-val-regex-pattern"));
                    if (!regex.test(elem.value)) {
                        this.failValidation(elem, "data-val-regex");
                        continue;
                    }
                }

                //Равенство значения поля с другим значением поля data-val-equalto-other
                if (elem.getAttribute("data-val-equalto")) {
                    //Получаем id из data-val-equalto-other
                    var id = elem.getAttribute("data-val-equalto-other").replace("*.", "#");
                    if (elem.value != this.form.querySelector(id).value) {
                        this.failValidation(elem, "data-val-equalto");
                        continue;
                    }
                }
            }
        }
        return this.validationSuccess;
    }
}

var form = document.querySelector("form");
var validator = new Validator(form);

form.addEventListener("submit", (event) => {
    if (!validator.validate())
        event.preventDefault();
});
