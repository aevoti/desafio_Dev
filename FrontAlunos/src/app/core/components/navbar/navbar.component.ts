import { OnInit, ViewChild, ElementRef, Component } from '@angular/core';

@Component({
    selector: 'app-navbar',
    templateUrl: './navbar.component.html',
    styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

    constructor(
    ) {}

    @ViewChild('navBurger', {static: true}) private navBurger: ElementRef;
    @ViewChild('navMenu', {static: true}) private navMenu: ElementRef;

    ngOnInit(): void {

    }

    public toggleNavbar() {
        this.navBurger.nativeElement.classList.toggle('is-active');
        this.navMenu.nativeElement.classList.toggle('is-active');
    }
}
