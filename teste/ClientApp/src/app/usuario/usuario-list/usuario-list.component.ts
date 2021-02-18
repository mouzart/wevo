import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';

@Component({
  selector: 'app-usuario-list',
  templateUrl: './usuario-list.component.html',
})
export class UsuarioListComponent {

  public _baseUrl = '';
  public usuarios: any[] = [];
  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.getList();
  }

  delete(id: any) {
    this.http.delete<any>(this._baseUrl + 'api/usuarios/' + id).subscribe(result => {
      console.log(result);
      this.getList();
    }, error => console.error(error));
  }

  getList() {
    this.http.get<any[]>(this._baseUrl + 'api/usuarios/').subscribe(result => {
      this.usuarios = result;
    }, error => console.error(error));
  }
}
