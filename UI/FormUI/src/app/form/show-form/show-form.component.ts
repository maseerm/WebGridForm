import { Component, OnInit } from '@angular/core';
import {SharedService} from 'src/app/shared.service';


@Component({
  selector: 'app-show-form',
  templateUrl: './show-form.component.html'
})

export class ShowFormComponent implements OnInit {

  constructor(private service:SharedService){ }

    formList:any=[];
    modalTitle:string;
    frm:any;
    formId:any=0;
    formDataList:any=[];
    formDataModelList:any=[];
    activateAddFormComp:boolean=false;
    activateAddFormData:boolean=false;
    activateEditFormData:boolean=false;
    activateFormData:boolean=false;
    activateDisplayMessage:boolean=false;
    validationMessage:string;
    frmData:any;
    formDataId:string;
    col1:string;
    col2:string;
    col3:string;
    col4:string;
    col5:string;
    
   
  ngOnInit(): void { 
    this.refreshFormList();
  }

  refreshFormList(){
    this.service.getForms().subscribe(data=>{
      this.formList=data;
    });
  }

  deleteFormClick(item:any){
    if(confirm('Are you sure??')){
      this.service.deleteForm(item.formId).subscribe(data=>{
        this.refreshFormList();
      })
    }
  }
  
  updateFormClick(item:any)
  {
    this.activateDisplayMessage=false;
    this.formId=item.formId;
    this.activateFormData=true;
    this.refreshFormDataList(this.formId);
  }

  addFormClick(){
    this.frm={
      formId:0,
      formName:""
    }
    this.modalTitle="Add a form";
    this.activateAddFormComp=true;
  }

  closeClick(){
    this.activateAddFormComp=false;
    this.refreshFormList();
  }

  addEnableButtonClick(){
    this.activateDisplayMessage=false;
    this.activateAddFormData=true;
    this.activateEditFormData=false;
  }

  addFormDataClick(){
    let formDatavalues=this.col1+'~'+this.col2+'~'+this.col3+'~'+this.col4+'~'+this.col5;
    let values = {formId:this.formId,formItem:formDatavalues};
    this.service.addFormData(values).subscribe(res=>{
    this.activateDisplayMessage=true;
    this.validationMessage="Form data added successfully"
    });
    this.reset();
    this.refreshFormDataList(this.formId);
  }

  updateFormDataClick(){
    let formDatavalues=this.col1+'~'+this.col2+'~'+this.col3+'~'+this.col4+'~'+this.col5;
    let values = {formDataId:this.formDataId,formItem:formDatavalues}
    this.service.updateFormData(values).subscribe(res=>{
    this.activateDisplayMessage=true;
    this.validationMessage="Form data updated successfully"
    });
    this.reset();
    this.refreshFormDataList(this.formId);
  }
    
  reset(){
    this.col1="";
    this.col2="";
    this.col3="";
    this.col4="";
    this.col5="";
  }

  refreshFormDataList(val:any){
   
    let listArr:any[]=[];
    this.service.getFormData(val).subscribe(data=>{
    this.formDataList=data;         
    });
   
    for (var item of this.formDataList) {
      let formDataModel ={formId:'',
      formDataId: '',
      col1: '',
      col2: '',
      col3: '',
      col4: '',
      col5: ''}
      let myArr:any[]=[];
      formDataModel.formId=item.formId,
      formDataModel.formDataId=item.formDataId,
      myArr = item.formItem.split('~');
      formDataModel.col1=myArr[0],
      formDataModel.col2=myArr[1],
      formDataModel.col3=myArr[2],
      formDataModel.col4=myArr[3],
      formDataModel.col5=myArr[4] 
      listArr.push(formDataModel);
    }
      this.formDataModelList=listArr;
    }

    updateFormDataGidClick(item:any){
      this.activateDisplayMessage=false;
      this.activateAddFormData=false;
      this.activateEditFormData=true;
      this.col1=item.col1;
      this.col2=item.col2;
      this.col3=item.col3;
      this.col4=item.col4;
      this.col5=item.col5;
      this.formDataId=item.formDataId;
    }

    deleteFormDataClick(item:any){
      this.formId=item.formId;
      if(confirm('Are you sure??')){
        this.service.deleteFormData(item.formDataId).subscribe(data=>{
        this.activateDisplayMessage=true;
        this.validationMessage="Form data deleted successfully"
        })
      }
      this.refreshFormDataList(this.formId);
    }

    keyPressAlphaNumeric(event:any) {
      let inp = String.fromCharCode(event.keyCode);
      if (/[a-z\d\s]/.test(inp)) {
        return true;
      } else {
        event.preventDefault();
        return false;
      }
    }
}
