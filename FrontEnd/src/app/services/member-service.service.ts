import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Member } from '../models/member.model';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

const baseUrl = `${environment.memberServiceUrl}`

@Injectable({
  providedIn: 'root'
})
export class MemberServiceService {

  constructor(private http: HttpClient) { }
  
  formData: Member = new Member();
  list!: Member[];

  // get all members data
  // getMembers(): Observable<Member[]>{
  //   return this.http.get<Member[]>(baseUrl);
  // }

  // // add new member
  // addMember(data: any):Observable<any>{
  //   return this.http.post(baseUrl, data);
  // }

  postMemberData() {
    return this.http.post(baseUrl, this.formData);
  }

  putMemberData() {
    return this.http.put(`${baseUrl}/${this.formData.id}`, this.formData);
  }

  deleteMember(id: number) {
    return this.http.delete(`${baseUrl}/${id}`);
  }

  refreshData(){
    this.http.get<Member[]>(baseUrl).subscribe(res=> this.list = res as Member[]);
  }

  refreshData111() {
    this.http.get(baseUrl)
      .toPromise()
      .then(res => this.list = res as Member[]);
  }
}
