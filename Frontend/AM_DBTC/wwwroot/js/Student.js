function openAddModal() {
    document.getElementById('addModal').style.display = 'flex';
}

function openEditModal(rollNo, name, semester, course) {
    document.getElementById('editRollNo').value = rollNo;
    document.getElementById('editName').value = name;
    document.getElementById('editSemester').value = semester;
    document.getElementById('editCourse').value = course;
    document.getElementById('editModal').style.display = 'flex';
}

function confirmDelete(rollNo, name) {
    document.getElementById('deleteRollNo').value = rollNo;
    document.getElementById('deleteMessage').textContent =
        'Are you sure you want to delete ' + name + '? This action cannot be undone.';
    document.getElementById('deleteModal').style.display = 'flex';
}

function closeModal(modalId) {
    document.getElementById(modalId).style.display = 'none';
}

// close modal if user clicks outside the box
document.querySelectorAll('.modal-overlay').forEach(function (overlay) {
    overlay.addEventListener('click', function (e) {
        if (e.target === overlay) {
            overlay.style.display = 'none';
        }
    });
});

// auto submit filter form on select change
document.querySelectorAll('.student-select').forEach(function (sel) {
    sel.addEventListener('change', function () {
        this.closest('form').submit();
    });
});