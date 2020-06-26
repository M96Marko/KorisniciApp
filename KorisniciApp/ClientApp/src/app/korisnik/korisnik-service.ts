import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { KorisnikModel } from 'src/app/korisnik/korisnik-model';
import { Subject } from "rxjs";

@Injectable({
  providedIn: 'root'
})

@NgModule({
  imports: [
    HttpClient,
  ]
})

export class KorisnikService {
  url: string = "";
  goToEdit = new Subject<number>();

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl + 'korisnici';
  }

  createKorisnik() {
    return this.httpClient.get(this.url + '/create');
  }

  getAllMjesta() {
    return this.httpClient.get(this.url + '/getAllMjesta');
  }

  getAllKorisnici() {
    return this.httpClient.get(this.url);
  }

  getKorisnikById(id: number) {
    return this.httpClient.get<KorisnikModel>(this.url + '/id/' + id);
  }

  saveKorisnik(korisnikModel: KorisnikModel) {
    return this.httpClient.post<KorisnikModel>(this.url + '/save', korisnikModel);
  }

  deleteKorisnik(id: number) {
    return this.httpClient.delete(this.url + '/delete/' + id);
  }
}
