import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
    selector: 'app-continue-btn',
    templateUrl: './continue-btn.component.html',
    styleUrls: ['./continue-btn.component.css']
})
export class ContinueBtnComponent implements OnInit {
    @Input() text: string;
    @Input() color: string;
    @Input() form: FormGroup;
    @Output() btnClick = new EventEmitter();

    constructor() { }

    ngOnInit(): void { }

    onClick() {
        this.btnClick.emit();
    }
}