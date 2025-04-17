import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-print-map',
  imports: [FormsModule],
  templateUrl: './print-map.component.html',
  styleUrl: './print-map.component.css'
})
export class PrintMapComponent {
  cityName: string = '';
  constructor(private http: HttpClient) {}

  onprint() {
    this.http.get("http://localhost:5295/api/render/city?name=" + this.cityName, { responseType: "blob"}).subscribe((response: any) => {
      console.log(response);
      const blob = new Blob([response], { type: 'application/pdf' });
      const url = window.URL.createObjectURL(blob);
      const a = document.createElement('a');
      a.href = url;
      a.download = this.cityName + '.pdf';
      a.click();
      window.URL.revokeObjectURL(url);
    });
  }
}
