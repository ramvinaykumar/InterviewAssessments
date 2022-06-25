import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Member } from 'src/app/models/member.model';
import { MemberServiceService } from 'src/app/services/member-service.service';

@Component({
  selector: 'app-member-detail',
  templateUrl: './member-detail.component.html',
  styleUrls: []
})
export class MemberDetailComponent implements OnInit {

  constructor(public apiService: MemberServiceService, private toastr: ToastrService) { }

  ngOnInit(): void {
  }
  onSubmit(form: NgForm) {
    if (this.apiService.formData.id == 0)
      this.insertRecord(form);
    else
      this.updateRecord(form);
  }

  insertRecord(form: NgForm) {
    this.apiService.postMemberData().subscribe(
      res => {
        this.resetForm(form);
        this.apiService.refreshData();
        this.toastr.success('Inserted successfully', 'Member Management')
      },
      err => { console.log(err); }
    );
  }

  updateRecord(form: NgForm) {
    this.apiService.putMemberData().subscribe(
      res => {
        this.resetForm(form);
        this.apiService.refreshData();
        this.toastr.info('Updated successfully', 'Member Management')
      },
      err => { console.log(err); }
    );
  }

  resetForm(form: NgForm) {
    form.form.reset();
    this.apiService.formData = new Member();
  }
}
