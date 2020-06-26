import { Component, OnInit, ViewChild  } from '@angular/core';
import { KorisnikService } from './../korisnik-service';
import { NgModule } from '@angular/core';
import { AgGridAngular } from 'ag-grid-angular';
import { Router} from '@angular/router';

@Component({
  selector: 'app-korisnik-list',
  templateUrl: './korisnik-list.component.html'
  //styleUrls: ['/styles.scss']
})

  @NgModule({
})

export class KorisnikListComponent implements OnInit {
  @ViewChild('agGrid', null) agGrid: AgGridAngular;

  constructor(private korisnikService: KorisnikService, private _router: Router,) {
  }

  columnDefs = [
    { headerName: 'Id', field: 'id', sortable: true },
    { headerName: 'Ime', field: 'ime', sortable: true, filter: true },
    { headerName: 'Prezime', field: 'prezime', sortable: true, filter: true },
    { headerName: 'Adresa', field: 'adresa', filter: true },
    { headerName: 'Broj mobitela', field: 'brojMobitela', filter: true},
    { headerName: 'Mjesto', field: 'mjestoId', sortable: true, filter: true },
    { headerName: 'Email', field: 'email', filter: true },
    { headerName: 'Spol', field: 'spol' }
  ];

  rowData: any;

  ngOnInit() {
    this.rowData = this.korisnikService.getAllKorisnici();
  }

  createKorisnik() {
    this._router.navigate(['/edit'])
  }

  editKorisnik() {
    const selectedNodes = this.agGrid.api.getSelectedNodes();
    const selectedData = selectedNodes.map(node => node.data);
    const selectedId = +selectedData.map(node => node.id);

    if (selectedId != null) {
      this._router.navigate(['/edit', selectedId])

      this.rowData = this.korisnikService.getAllKorisnici();
      this.agGrid.api.refreshRows(selectedNodes);
    }
    else {
        alert('Niste odabrali korisnika!')
    }
  }

  deleteKorisnik() {
    const selectedNodes = this.agGrid.api.getSelectedNodes();
    const selectedData = selectedNodes.map(node => node.data);
    const selectedId = +selectedData.map(node => node.id);

    if (selectedId != null) {
      this.korisnikService.deleteKorisnik(selectedId).subscribe(() => { });
      this.rowData = this.korisnikService.getAllKorisnici();
      this.agGrid.api.refreshRows(selectedNodes);
    }
    else if (this.rowData == null) {
      alert("Nema podataka za brisanje!")
    }
    else {
      alert("Niste odabrali korisnika!")
    }
  }
}
