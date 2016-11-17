loginFunctions = {
    HideInput: function HideInput(errorLabelId, usernameTxtboxId, passwordTxtboxId) {

        errorLabel = document.getElementById(errorLabelId);
        usernameTxtbox = document.getElementById(usernameTxtboxId);
        passwordTxtbox = document.getElementById(passwordTxtboxId);

        if (!isNullOrWhitespace(usernameTxtbox.value) && !isNullOrWhitespace(passwordTxtbox.value)) {

            usernameTxtbox.disabled = true;
            usernameTxtbox.style.color = "lightgray";
            passwordTxtbox.disabled = true;
            passwordTxtbox.style.color = "lightgray";

            if (errorLabel !== null) {

                errorLabel.style.display = 'none';
            }
        }
    }
};

function isNullOrWhitespace(input) {

    if (typeof input === 'undefined' || input === null) return true;

    return input.replace(/\s/g, '').length < 1;
}