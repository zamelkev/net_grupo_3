import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  // atributos
  title: string = 'angular';



  // constructor

  // metodos
  hello() {
    this.title = "titulo cambiado desde un boton"
  }
}
