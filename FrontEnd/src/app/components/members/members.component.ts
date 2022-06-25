import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Member } from 'src/app/models/member.model';
import { MemberServiceService } from 'src/app/services/member-service.service';

@Component({
  selector: 'app-members',
  templateUrl: './members.component.html',
  styleUrls: []
})
export class MembersComponent implements OnInit {

  constructor(public apiService: MemberServiceService, private toaster: ToastrService) { }

  ngOnInit(): void {
    this.apiService.refreshData();
  }

  populateSelectedData(selectedRecord: Member) {
    this.apiService.formData = Object.assign({}, selectedRecord);
  }

  onDelete(id: number) {
    if (confirm('Are you sure to delete this record?')) {
      this.apiService.deleteMember(id)
        .subscribe(
          res => {
            this.apiService.refreshData();
            this.toaster.error("Deleted successfully", 'Member Management');
          },
          err => { console.log(err) }
        )
    }
  }

}
