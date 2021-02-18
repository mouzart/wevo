import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-usuario-form',
  templateUrl: './usuario-form.component.html',
})
export class UsuarioFormComponent {
  public usuario: any = { nome: '', cpf: '', email: '', telefone: '', sexo: '', dataNascimento: Date.now };
  public _baseUrl = '';
  public id: any;
  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string, private route: ActivatedRoute, public router: Router) {
    this._baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id');
    if (this.id !== '0') {
      this.http.get<any>(this._baseUrl + 'api/usuarios/' + this.id).subscribe(result => {
        this.usuario = result;
      }, error => console.error(error));
    }
  }

  public save() {
    console.log('save', this.usuario);
    if (this.usuario.id > 0) {
      this.http.put<any>(this._baseUrl + 'api/usuarios/' + this.usuario.id, this.usuario).subscribe(result => {
        this.usuario = result;
        alert('Editado com sucesso!');
      }, error => console.error(error));
    } else {
      this.usuario.id = undefined;
      this.http.post<any>(this._baseUrl + 'api/usuarios', this.usuario).subscribe(result => {
        this.usuario = result;
        alert('Salvo com sucesso!');
      }, error => console.error(error));
    }

  }
}
