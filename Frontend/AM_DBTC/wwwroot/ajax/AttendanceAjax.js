let currentPage = 1;

document.addEventListener('DOMContentLoaded', function ()
{

    const filterBtn = document.querySelector('.attendance-search-btn');
    const studentSearch = document.getElementById('studentNameSearch');
    const course = document.getElementById('courseFilter');
    const month = document.getElementById('monthFilter');
    const tableBody = document.querySelector('.attendance-table tbody');
    const summaryCards = document.querySelector('.summary-cards');
    const pagination = document.querySelector('.pagination');

    function applyFilters()
    {

        const userName = studentSearch?.value || '';
        const courseVal = course?.value || '';
        const monthVal = month?.value || '';

        const url =
            `/Attendance/AttendanceView?userName=${encodeURIComponent(userName)}`
            + `&course=${encodeURIComponent(courseVal)}`
            + `&month=${encodeURIComponent(monthVal)}`
            + `&page=${currentPage}`
            + `&pageSize=5`;

        fetch(url, {headers: {"X-Requested-With": "XMLHttpRequest"}})
            .then(res => res.text())
            .then(html =>
            {

                const doc = new DOMParser().parseFromString(html, 'text/html');

                // update table
                const newTable = doc.querySelector('.attendance-table tbody');
                if (newTable) tableBody.innerHTML = newTable.innerHTML;

                // update cards
                const newCards = doc.querySelector('.summary-cards');
                if (newCards) summaryCards.innerHTML = newCards.innerHTML;

                // update pagination safely
                const newPagination = doc.querySelector('.pagination');
                if (newPagination) pagination.innerHTML = newPagination.innerHTML;

            })
            .catch(err => console.error(err));
    }

    // filter button
    filterBtn?.addEventListener('click', function ()
    {
        currentPage = 1;
        applyFilters();
    });

    // enter search
    studentSearch?.addEventListener('keydown', function (e)
    {
        if (e.key === 'Enter') {
            e.preventDefault();
            currentPage = 1;
            applyFilters();
        }
    });

    // expose pagination
    window.changePage = function (page)
    {
        currentPage = page;
        applyFilters();
    };

});