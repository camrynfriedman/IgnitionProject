import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-return-btn',
  templateUrl: './return-btn.component.html',
  styleUrls: ['./return-btn.component.css']
})
export class ReturnBtnComponent implements OnInit {
    @Input() text: string;
    @Input() color: string;
    @Output() btnClick = new EventEmitter()

    constructor() { }

    ngOnInit(): void { }

    onClick() {
        this.btnClick.emit();
    }
}
