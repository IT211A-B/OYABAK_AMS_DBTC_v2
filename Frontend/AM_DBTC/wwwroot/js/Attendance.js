//document.querySelectorAll('.attendance-select').forEach(function (sel) {
//    sel.addEventListener('change', function () {
//        this.closest('form').submit();
//    });
//});

document.querySelectorAll('.attendance-select, #studentNameSearch').forEach(el => {
    el.addEventListener('keydown', e => {
        if (e.key === 'Enter') e.preventDefault(); // prevent form submit on enter huhuness
    });
});