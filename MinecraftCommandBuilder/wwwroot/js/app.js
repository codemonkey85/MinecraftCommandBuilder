export function CopyTextToClipboard(textToCopy) {
    if (typeof ClipboardItem && navigator.clipboard.write) {
        // NOTE: Safari locks down the clipboard API to only work when triggered
        //   by a direct user interaction. You can't use it async in a promise.
        //   But! You can wrap the promise in a ClipboardItem, and give that to
        //   the clipboard API.
        //   Found this on https://developer.apple.com/forums/thread/691873
        const text = new ClipboardItem({
            "text/plain": new Blob([textToCopy], {type: "text/plain"}),
        });
        navigator.clipboard
            .write([text])
            .catch((error) => {
                alert(error);
            });
    } else {
        // NOTE: Firefox has support for ClipboardItem and navigator.clipboard.write,
        //   but those are behind `dom.events.asyncClipboard.clipboardItem` preference.
        //   Good news is that other than Safari, Firefox does not care about
        //   Clipboard API being used async in a Promise.
        navigator.clipboard
            .writeText(textToCopy)
            .catch((error) => {
                alert(error);
            });
    }
}
