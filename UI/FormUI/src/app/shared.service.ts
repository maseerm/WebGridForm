import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders  } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})

export class SharedService{
  private accessPointUrl: string = 'http://localhost:23219/api';

  constructor(private http:HttpClient) {}
  
  getForms() {
    return this.http.get(this.accessPointUrl+'/Forms');
  }

  deleteForm(val:any){
    return this.http.delete(this.accessPointUrl+'/Forms/?formId='+val);
  }

  addForm(val:any){
    return this.http.post(this.accessPointUrl+'/Forms',val);
  }
    
  getFormData(val:any) {
    return  this.http.get(this.accessPointUrl+'/FormData?formId='+val);
  }

  addFormData(val:any){
    return this.http.post(this.accessPointUrl+'/FormData',val);
  }

  updateFormData(val:any){
    return this.http.patch(this.accessPointUrl+'/FormData',val);
  }

  deleteFormData(val:any){
    return this.http.delete(this.accessPointUrl+'/FormData/?formDataId='+val);
  }
  
}
