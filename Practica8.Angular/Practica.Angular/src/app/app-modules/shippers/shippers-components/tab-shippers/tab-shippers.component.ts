import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTabGroup } from '@angular/material/tabs';
import { ShareDataService } from 'src/app/services/share-Data/share-data.service';
import { FormShippersComponent } from '../form-shippers/form-shippers.component';

@Component({
  selector: 'app-tab-shippers',
  templateUrl: './tab-shippers.component.html',
  styleUrls: ['./tab-shippers.component.scss']
})
export class TabShippersComponent implements OnInit {
  @ViewChild('tabGroup') tabGroup!: MatTabGroup;
  constructor(private shareService: ShareDataService) { }

  ngOnInit(): void {
    this.shareService.idTab$.subscribe(id => {
      this.tabGroup.selectedIndex = id;
    })
  }
}
