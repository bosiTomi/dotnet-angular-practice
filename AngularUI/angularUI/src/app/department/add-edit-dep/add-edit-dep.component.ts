import { Component, Input, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-dep',
  templateUrl: './add-edit-dep.component.html',
  styleUrls: ['./add-edit-dep.component.css']
})
export class AddEditDepComponent implements OnInit {
  @Input() dep: any;
  DepartmentId:string;
  DepartmentName:string;
  
  constructor(private service: SharedService) { }

  ngOnInit(): void{
    this.DepartmentId = this.dep.DepartmentId;
    this.DepartmentName = this.dep.DepartmentName;
  }
  
  addDepartment() {
    var value = {
      DepartmentId: this.DepartmentId,
      DepartmentName: this.DepartmentName
    };
    this.service.addDepartment(value).subscribe(res =>{
      alert(res.toString());
    });
  }

  updateDepartment() {
    var value = {
      DepartmentId: this.DepartmentId,
      DepartmentName: this.DepartmentName
    };
    this.service.updateDepartment(value).subscribe(res =>{
      alert(res.toString());
    });
  }

}
