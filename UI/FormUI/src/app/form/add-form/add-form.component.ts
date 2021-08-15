import { Component, OnInit,Input  } from '@angular/core';
import {SharedService} from 'src/app/shared.service';

@Component({
  selector: 'app-add-form',
  templateUrl: './add-form.component.html'
})


export class AddFormComponent implements OnInit {

  constructor(private service:SharedService) { }

  @Input() frm:any;
  formId:string;
  formName:string;

  ngOnInit(): void {
    this.formId=this.frm.formId;
    this.formName=this.frm.formName;
  }

  addForm(){
      let values = {formId:this.formId,
      formName:this.formName};
    this.service.addForm(values).subscribe(res=>{
    });
  }

}
