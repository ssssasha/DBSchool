const uri = 'api/Students';
let students = [];

function getStudents() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayStudents(data))
        .catch(error => console.error('Unable to get students.', error));
}

function addStudent() {
    const addFullNameTextbox = document.getElementById('add-fullName');
    const addYearTextbox = document.getElementById('add-year');
    const addGradeIdTextbox = document.getElementById('add-gradeId');

    const student = {
        fullName: addFullNameTextbox.value.trim(),
        year: addYearTextbox.value.trim(),
        gradeId: addGradeIdTextbox.value.trim(),
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(student)
    })
        .then(response => response.json())
        .then(() => {
            getStudents();
            addFullNameTextbox.value = '';
            addYearTextbox.value = '';
            addGradeIdTextbox.value = '';
        })
        .catch(error => console.error('Unable to add student.', error));
}

function deleteStudent(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getStudents())
        .catch(error => console.error('Unable to delete student.', error));
}

function displayEditForm(id) {
    const student = students.find(student => student.id === id);

    document.getElementById('edit-id').value = student.id;
    document.getElementById('edit-fullName').value = student.fullName;
    document.getElementById('edit-year').value = student.year;
    document.getElementById('edit-gradeId').value = student.gradeId;
    document.getElementById('editForm').style.display = 'block';
}

function updateStudent() {
    const studentId = document.getElementById('edit-id').value;
    const student = {
        id: parseInt(studentId, 10),
        fullName: document.getElementById('edit-fullName').value.trim(),
        year: document.getElementById('edit-year').value.trim(),
        gradeId: document.getElementById('edit-gradeId').value.trim()
    };

    fetch(`${uri}/${studentId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(student)
    })
        .then(() => getStudents())
        .catch(error => console.error('Unable to update student.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}


function _displayStudents(data) {
    const tBody = document.getElementById('students');
    tBody.innerHTML = '';


    const button = document.createElement('button');

    data.forEach(student => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${student.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteStudent(${student.id})`);

        let tr = tBody.insertRow();


        let td1 = tr.insertCell(0);
        let textNodeFullName = document.createTextNode(student.fullName);
        td1.appendChild(textNodeFullName);

        let td2 = tr.insertCell(1);
        let textNodeYear = document.createTextNode(student.year);
        td2.appendChild(textNodeYear);

        let td3 = tr.insertCell(2);
        let textNodeGradeId = document.createTextNode(student.gradeId);
        td3.appendChild(textNodeGradeId);

        let td4 = tr.insertCell(3);
        td4.appendChild(editButton);

        let td5 = tr.insertCell(4);
        td5.appendChild(deleteButton);
    });

    students = data;
}

