import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-dep',
  templateUrl: './show-dep.component.html',
  styleUrls: ['./show-dep.component.css']
})
export class ShowDepComponent implements OnInit {
  departmentList: any = [];
  modalTitle: string;
  activateAddEditDepComp: boolean = false;
  dep: any;

  constructor(private service: SharedService) { }
  
  ngOnInit(): void {
    this.refreshDepList();
  }

  showModal(){
    console.log("randy");
    this.dep={
      DepartmentId: 0,
      DepartmentName: ""
    }
    this.modalTitle = "Add Department";
    this.activateAddEditDepComp = true;
    
  }

  closeModal(){
    this.activateAddEditDepComp = false;
    this.refreshDepList();
  }

  editButtonModal(item){
    this.dep = item;
    this.modalTitle = "Edit Department";
    this.activateAddEditDepComp = true;
  }

  deleteModal(item){
    if(confirm('Are you sure?')){
      this.service.deleteDepartment(item.DepartmentId).subscribe(data =>{
        alert(data.toString());
        this.refreshDepList();
      })
    }
  }


  refreshDepList(){
    this.service.getDepList().subscribe(data =>{
      this.departmentList = data;
    })
  }
  
}
