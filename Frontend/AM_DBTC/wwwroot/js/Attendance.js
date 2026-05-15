document.querySelectorAll('.attendance-select').forEach(function (sel) {
    sel.addEventListener('change', function () {
        this.closest('form').submit();
    });
});