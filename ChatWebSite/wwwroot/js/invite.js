var form = document.querySelector("form");

function submit(block) {
    for (var i = 0; i < form.elements.length; i++) {
        var element = form.elements[i];
        if (element.tagName == "INPUT" && element.id != "") {
            element.value = block.querySelector("#" + element.id).innerText;
        }
    }
    form.submit();
}