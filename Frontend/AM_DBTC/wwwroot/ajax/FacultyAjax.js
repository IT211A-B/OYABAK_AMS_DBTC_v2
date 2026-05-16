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
    var searchInput = document.querySelector('.faculty-search');
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
    document.querySelectorAll('.faculty-select').forEach(function (sel)
    {
        sel.addEventListener('change', function ()
        {
            applyFilters();
        });
    });

    //// manual submission
    //var applyBtn = document.querySelector('.apply-btn');
    //if (applyBtn) {
    //    applyBtn.addEventListener('click', function (e) {
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
    var search = document.querySelector('.faculty-search')?.value ?? '';
    var semester = document.querySelector('select[name="semester"]')?.value ?? '';

    var url = '/Faculty/FacultyView'
        + '?search=' + encodeURIComponent(search)
        + '&semester=' + encodeURIComponent(semester);

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

            var newTbody = doc.querySelector('.faculty-table tbody');
            var oldTbody = document.querySelector('.faculty-table tbody');
            if (newTbody && oldTbody) oldTbody.innerHTML = newTbody.innerHTML;

            history.pushState(null, '', url);
        })
        .catch(function (err)
        {
            console.error('Faculty filter error:', err);
        })
        .finally(function ()
        {
            setTableLoading(false);
        });
}

function setTableLoading(loading)
{
    var tbody = document.querySelector('.faculty-table tbody');
    if (!tbody) return;
    tbody.style.opacity = loading ? '0.4' : '1'; tbody.style.pointerEvents = loading ? 'none' : '';
}

// modals
function openAddModal()
{
    document.getElementById('addModal').style.display = 'flex';
}

function openEditModal(empId, name, department, courses)
{
    document.getElementById('editEmpId').value = empId;
    document.getElementById('editName').value = name;
    document.getElementById('editDepartment').value = department;
    document.getElementById('editCourses').value = courses;
    document.getElementById('editModal').style.display = 'flex';
}

function confirmDelete(empId, name)
{
    document.getElementById('deleteEmpId').value = empId;
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
            console.error('Add faculty error:', err);
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
            console.error('Edit faculty error:', err);
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
            console.error('Delete faculty error:', err);
        });
}