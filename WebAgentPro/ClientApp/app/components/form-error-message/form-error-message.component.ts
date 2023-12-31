import { Component, Input } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-form-error-message',
  templateUrl: './form-error-message.component.html',
  styleUrls: ['./form-error-message.component.css']
})
export class FormErrorMessageComponent {
    @Input() control: FormControl;
    @Input() errorType: string;
    @Input() errorMessage: string;

    hasError(): boolean {
        return this.control.hasError('required') && this.control.touched;
    }
}
