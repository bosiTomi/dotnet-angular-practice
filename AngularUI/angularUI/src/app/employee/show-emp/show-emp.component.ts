import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-emp',
  templateUrl: './show-emp.component.html',
  styleUrls: ['./show-emp.component.css']
})
export class ShowEmpComponent {
  employeeList: any = [];
  modalTitle: string;
  activateAddEditEmpComp: boolean = false;
  emp: any;

  constructor(private service: SharedService) { }
  
  ngOnInit(): void {
    this.refreshEmpList();
  }

  showModal(){
    console.log("randy");
    this.emp={
      EmployeeId: 0,
      EmployeeName: "",
      Department: "",
      DateOfJoining: "",
      PhotoFileName: "anonymous.png"
    }
    this.modalTitle = "Add Employee";
    this.activateAddEditEmpComp = true;
    
  }

  closeModal(){
    this.activateAddEditEmpComp = false;
    this.refreshEmpList();
  }

  editButtonModal(item){
    this.emp = item;
    this.modalTitle = "Edit Employee";
    this.activateAddEditEmpComp = true;
  }

  deleteModal(item){
    if(confirm('Are you sure?')){
      this.service.deleteEmployee(item.EmployeeId).subscribe(data =>{
        alert(data.toString());
        this.refreshEmpList();
      })
    }
  }

  refreshEmpList(){
    this.service.getEmpList().subscribe(data =>{
      this.employeeList = data;
    })
  }
}
