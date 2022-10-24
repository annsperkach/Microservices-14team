import { Component } from '@angular/core';
import { Purchases } from './models/purchases';
import { PurchaseServiceService } from './services/purchase-service.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Client.UI';
  purchases: Purchases[] = [];

  constructor(private purchaseService : PurchaseServiceService) {}

ngOnInit(): void {
 this.purchaseService
 .getPurchases()
 .subscribe((result: Purchases[]) => (this.purchases = result));
}

}
