import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Student } from 'src/app/models/Student';
import { StudentsService } from './students.service';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.sass']
})
export class StudentsComponent implements OnInit {

  public modalRef: BsModalRef
  public studentForm: FormGroup
  public title = 'Alunos'
  public type = 'novo aluno'
  public studentSelected: Student
  public mode = 'post'
  public students: Student[]
  public paramsModal: {}
  public alert:boolean = false
  public paramsAlert: {}
  public filterName:string
  public searchStudent:string = ''

  modalDelete(deleteModal: TemplateRef<any>, id: number, nome: string) {
    const initialState = {
      nome: nome,
      alunoId: id
    };

    this.modalRef = this.modalService.show(deleteModal);
    this.paramsModal = initialState

  }

  constructor(
    private fb: FormBuilder,
    private modalService: BsModalService,
    private studentService: StudentsService ) {

    this.createForm()
  }

  ngOnInit(): void {
    this.loadStudents()
  }

  loadStudents() {
    this.studentService.getAll().subscribe(
      (students: Student[]) => {
        this.students = students
      },
      (error: any) => {
        console.log(error)
      }
    )
  }

  createForm() {
    this.studentForm = this.fb.group({
      alunoId: [''],
      nome:['', Validators.required],
      email:[''],
      turma:['']
    })
  }

  saveStudent(student: Student) {
    (student.alunoId !== 0) ? this.mode = 'put' : 'post'

      this.studentService[this.mode](student).subscribe(
        (response: Student) => {
          this.loadStudents()
          this.back()
          this.alertLoad('alert alert-success', 'Salvo com sucesso!')
        },
        (error: any) => {
          this.alertLoad('alert alert-danger', error)
        }
      )
  }

  deleteStudent(id) {
    this.studentService.delete(id).subscribe(
      (response:any) => {
        this.modalRef.hide()
        this.loadStudents()
        this.alertLoad('alert alert-success', 'Aluno excluído com sucesso!')
      },
      (error: any) => {
        this.alertLoad('alert alert-danger', error)
      }
    )
  }

  studentSubmit() {
    this.saveStudent(this.studentForm.value)
    this.mode = 'post'
  }

  studentSelect(student: Student) {
    this.studentSelected = student
    this.studentForm.patchValue(student)
  }

  addStudent() {
    this.studentSelected = new Student()
    this.studentForm.patchValue(this.studentSelected)
  }

  alertLoad(classType, text) {
    this.paramsAlert = {
      class: classType,
      text: text
    }

    this.alert = true
    setTimeout(() => {
      this.alert = false
    }, 2000)
  }

  onFilterStudent() {
    this.searchStudent = this.filterName
  }

  back() {
    this.studentSelected = null
  }

}

