import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { PrintMapComponent } from "./print-map/print-map.component";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, PrintMapComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'interview';
}
