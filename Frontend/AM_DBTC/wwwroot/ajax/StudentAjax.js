document.addEventListener('DOMContentLoaded', function ()
{

    // filter button click
    var filterBtn = document.querySelector('.filter-btn');
    if (filterBtn)
    {
        filterBtn.addEventListener('click', function (e)
        {
            e.preventDefault();
            applyFilters();
        });
    }

    // enter key on search input
    var searchInput = document.querySelector('.student-search');
    if (searchInput)
    {
        searchInput.addEventListener('keydown', function (e)
        {
            if (e.key === 'Enter')
            {
                e.preventDefault();
                applyFilters();
            }
        });
    }

    // auto submit on select change
    document.querySelectorAll('.student-select').forEach(function (sel)
    {
        sel.addEventListener('change', function ()
        {
            applyFilters();
        });
    });

    //// manual submission
    //var applyBtn = document.querySelector('.apply-btn');
    //if (applyBtn)
    //{
    //    applyBtn.addEventListener('click', function (e)
    //    {
    //        e.preventDefault();
    //        currentPage = 1;
    //        applyFilters();
    //    });
    //}

    // close modal on overlay click
    document.querySelectorAll('.modal-overlay').forEach(function (overlay)
    {
        overlay.addEventListener('click', function (e)
        {
            if (e.target === overlay)
            {
                overlay.style.display = 'none';
            }
        });
    });
});

// filter
function applyFilters()
{
    var search = document.querySelector('.student-search')?.value ?? '';
    var semester = document.querySelector('select[name="semester"]')?.value ?? '';
    var branch = document.querySelector('select[name="branch"]')?.value ?? '';

    var url = '/Student/StudentView'
        + '?search=' + encodeURIComponent(search)
        + '&semester=' + encodeURIComponent(semester)
        + '&branch=' + encodeURIComponent(branch);

    setTableLoading(true);

    fetch(url, {headers: {'X-Requested-With': 'XMLHttpRequest'}})
        .then(function (res)
        {
            if (!res.ok) throw new Error('Network error');
            return res.text();
        })
        .then(function (html)
        {
            var parser = new DOMParser();
            var doc = parser.parseFromString(html, 'text/html');

            var newTbody = doc.querySelector('.students-table tbody');
            var oldTbody = document.querySelector('.students-table tbody');
            if (newTbody && oldTbody) oldTbody.innerHTML = newTbody.innerHTML;

            history.pushState(null, '', url);
        })
        .catch(function (err)
        {
            console.error('Student filter error:', err);
        })
        .finally(function ()
        {
            setTableLoading(false);
        });
}

function setTableLoading(loading)
{
    var tbody = document.querySelector('.students-table tbody');
    if (!tbody) return;
    tbody.style.opacity = loading ? '0.4' : '1'; tbody.style.pointerEvents = loading ? 'none' : '';
}

// modals
function openAddModal()
{
    document.getElementById('addModal').style.display = 'flex';
}

function openEditModal(rollNo, name, semester, course)
{
    document.getElementById('editRollNo').value = rollNo;
    document.getElementById('editName').value = name;
    document.getElementById('editSemester').value = semester;
    document.getElementById('editCourse').value = course;
    document.getElementById('editModal').style.display = 'flex';
}

function confirmDelete(rollNo, name)
{
    document.getElementById('deleteRollNo').value = rollNo;
    document.getElementById('deleteMessage').textContent = 'Are you sure you want to delete ' + name + '? This action cannot be undone.';
    document.getElementById('deleteModal').style.display = 'flex';
}

function closeModal(modalId)
{
    document.getElementById(modalId).style.display = 'none';
}

// add
function submitAdd(event)
{
    event.preventDefault();
    var form = event.target;
    var data = new FormData(form);

    fetch(form.action, {method: 'POST', body: data, headers: {'X-Requested-With': 'XMLHttpRequest'}})
        .then(function (res)
        {
            if (res.ok || res.redirected)
            {
                closeModal('addModal');
                form.reset();
                applyFilters();
            }
        })
        .catch(function (err)
        {
            console.error('Add student error:', err);
        });
}

// edit
function submitEdit(event)
{
    event.preventDefault();
    var form = event.target;
    var data = new FormData(form);

    fetch(form.action, {method: 'POST', body: data, headers: {'X-Requested-With': 'XMLHttpRequest'}})
        .then(function (res)
        {
            if (res.ok || res.redirected)
            {
                closeModal('editModal');
                applyFilters();
            }
        })
        .catch(function (err)
        {
            console.error('Edit student error:', err);
        });
}

// delete
function submitDelete(event)
{
    event.preventDefault();
    var form = event.target;
    var data = new FormData(form);

    fetch(form.action, {method: 'POST', body: data, headers: {'X-Requested-With': 'XMLHttpRequest'}})
        .then(function (res)
        {
            if (res.ok || res.redirected)
            {
                closeModal('deleteModal');
                applyFilters();
            }
        })
        .catch(function (err)
        {
            console.error('Delete student error:', err);
        });
}