export function CopyTextToClipboard(text) {
    navigator.clipboard
        .writeText(text)
        .then(function () {
            alert("Copied to clipboard!");
        })
        .catch(function (error) {
            alert(error);
        });
}
