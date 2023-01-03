import { Component } from '@angular/core';

@Component({
  selector: 'app-profile-image-selector',
  templateUrl: './profile-image-selector.component.html',
  styleUrls: ['./profile-image-selector.component.css']
})
export class ProfileImageSelectorComponent {
  fileSelected(): void {
    var input = document.getElementById('file');
    console.log(input);
  }
}
