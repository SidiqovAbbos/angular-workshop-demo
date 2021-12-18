import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTable } from '@angular/material/table';
import { Company } from 'src/app/core/models/company';
import { CompanyService } from 'src/app/core/services/company.service';
import { CompanyDialogComponent } from './company-dialog/company-dialog.component';

@Component({
  selector: 'app-company',
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.scss']
})
export class CompanyComponent implements OnInit {
  displayedColumns: string[] = ['name', 'website', 'actions'];
  dataSource: Company[] = [];

  @ViewChild(MatTable) table!: MatTable<Company>;

  constructor(private _companyService: CompanyService, 
    private _dialog: MatDialog) { }

  ngOnInit() {
    this._companyService.getItems().subscribe(data => {
      console.log(data);
      
      this.dataSource = data;
    })
  }

  addCompany() {
    this._dialog.open(CompanyDialogComponent, { data: {}, width: "300px" })
      .afterClosed()
      .subscribe((data: Company) => {
        if (data) {
          this._companyService.postItem(data).subscribe(company => {
            this.dataSource.push(company);
            this.table.renderRows();
          })
        }
      })
  }

  onEdit(item: Company) {
    this._dialog.open(CompanyDialogComponent, {data: Object.assign({}, item)})
      .afterClosed()
      .subscribe((data: Company) => {
        if (data) {
          this._companyService.editItem(data).subscribe(() => {
            const index = this.dataSource.findIndex(x => x.Id === data.Id);
            this.dataSource[index] = data;
            this.table.renderRows();
          })
        }
      })
  }

}
