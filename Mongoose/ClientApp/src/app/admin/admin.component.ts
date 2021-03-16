import { Component, OnInit } from '@angular/core';
import {AdminService} from './admin.service';
import {IFileInfo} from '../contracts/FileInfo';
import {NgbModal} from '@ng-bootstrap/ng-bootstrap';
import {AdminFormModalComponent} from './admin-form-modal/admin-form-modal.component';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  unmappedFiles: IFileInfo[];
  constructor(private adminService: AdminService, private modalService: NgbModal) { }

  openFormModal(file: IFileInfo) {
    const modalRef = this.modalService.open(AdminFormModalComponent);
    modalRef.componentInstance.file = file;
    modalRef.result.then((result) => {
      console.log(result);
    }).catch((error) => {
      console.log(error);
    });
  }
  ngOnInit() {
    this.adminService.getUnmappedFiles()
      .subscribe((data: IFileInfo[]) => {
        this.unmappedFiles = data;
      });
  }

}
