import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { KorisnikService } from './../korisnik-service';
import { NgModule } from '@angular/core';
import { KorisnikModel } from './../korisnik-model';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-korisnik-editor',
  templateUrl: './korisnik-editor.component.html'
  //styleUrls: ['/styles.scss']
})

@NgModule({

})

export class KorisnikEditorComponent implements OnInit {
  @Input() korisnikModel: KorisnikModel;

  constructor(private korisnikService: KorisnikService, private _router: Router, private _route: ActivatedRoute) {
  }

  spolovi = ['M', 'Ž'];
  mjesta: any

  ngOnInit() {
    this.mjesta = this.korisnikService.getAllMjesta().subscribe((data: any) => {
      if (data) this.mjesta = data;
    });;
    this._route.paramMap.subscribe(parameterMap => {
      const id = +parameterMap.get('id');
      if (id === 0) {
        this.create();
      }
      else {
        this.getKorisnik(id);
      }
    }
    );
  }

  create() {
    this.korisnikService.createKorisnik()
      .subscribe((data: any) => {
        if (data) this.korisnikModel = data;
      });
  }

  getKorisnik(korisnikId: number) {
    this.korisnikService.getKorisnikById(korisnikId)
      .subscribe((data: any) => {
        if (data) this.korisnikModel = data;
      });
  }

  saveKorisnik() {
    this.korisnikService.saveKorisnik(this.korisnikModel).subscribe(() => {});
    this._router.navigate(['list'])
  }
}
