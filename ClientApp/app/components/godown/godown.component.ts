import { Component, Input, Inject,  OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';  
import { Router, ActivatedRoute } from '@angular/router';
import { FormsModule } from '@angular/forms';  
import { StockService } from '../../common/services/stock.service';

@Component({
    selector: 'godown',
    templateUrl: './godown.component.html',
    styleUrls: ['./godown.component.css']
})

export class GodownComponent implements OnInit {
    
    public Inventory: InventoryMaster [] = [];  
    // to hide and Show Insert/Edit   
    AddTable: Boolean = false;  
    // To stored Informations for insert/Update and Delete  
    public sInventoryID : number = 0;  
    public sItemName = "";  
    public sStockQty : number  = 0;  
    public sReorderQty : number = 0;  
    public sPriorityStatus: boolean = false;  
    public bseUrl: string = "";  
      
    public schkName: string = "";  
    myName: string = "";  

    constructor(private http: Http, private _router: Router, private _stockService: StockService, @Inject('BASE_URL')base_url: string)
    {
        this.myName = "Shanu";  
        this.AddTable = false;  
        this.bseUrl = base_url; 
    }

    ngOnInit(): void {
        //throw new Error("Method not implemented.");
        this._stockService.getStock().subscribe(
            data => this.Inventory= data  
        ) 
    }

    getData(){
        this._stockService.getStock().subscribe(
            data => this.Inventory= data  
        ) 
    }

    AddInventory() {   
        this.AddTable = true;  
        // To stored Student Informations for insert/Update and Delete  
        this.sInventoryID = 0;  
        this.sItemName = "";  
        this.sStockQty = 50;  
        this.sReorderQty = 50;  
        this.sPriorityStatus = false;  
    }  

    // to show form for edit Inventory Information  
    editInventoryDetails(inventoryIDs : number, itemNames : string, stockQtys : number, reorderQtys : number , priorityStatus : number) {   
        this.AddTable = true;  
        this.sInventoryID = inventoryIDs;  
        this.sItemName = itemNames;  
        this.sStockQty = stockQtys;  
        this.sReorderQty = reorderQtys;  
        if (priorityStatus == 0)  
        {  
            this.sPriorityStatus = false;  
        }  
        else {  
            this.sPriorityStatus = true;  
        }  
         
    }  

    // If the InventoryId is 0 then insert the Inventory infromation using post and if the Inventory id is greater than 0 then edit using put mehod  
    addInventoryDetails(inventoryIDs: number, itemNames: string, stockQtys: number, reorderQtys: number, priorityStatus: boolean) {  
        var pStatus: number = 0;  
          
        this.schkName = priorityStatus.toString();  
        if (this.schkName == "true") {  
            pStatus = 1;  
        }  
        var headers = new Headers();  
        headers.append('Content-Type', 'application/json; charset=utf-8');  
        if (inventoryIDs == 0) {  
            this.http.post(this.bseUrl + 'api/InventoryMasterAPI/', JSON.stringify({ InventoryID: inventoryIDs, ItemName: itemNames, StockQty: stockQtys, ReorderQty: reorderQtys, PriorityStatus: pStatus }),  
                { headers: headers }).subscribe(  
                response => {  
                    this.getData();  
  
                }, error => {  
                }  
                );   
              
        }  
        else {  
            this.http.put(this.bseUrl + 'api/InventoryMasterAPI/' + inventoryIDs, JSON.stringify({ InventoryID: inventoryIDs, ItemName: itemNames, StockQty: stockQtys, ReorderQty: reorderQtys, PriorityStatus: pStatus }), { headers: headers })  
                .subscribe(response => {  
                    this.getData();  
  
                }, error => {  
                }  
                );   
             
        }  
        this.AddTable = false;  
        //  
        //  
        //this.http.get(this.bseUrl + 'api/InventoryMasterAPI/Inventory').subscribe(result => {  
        //    this.Inventory = result.json();  
        //}, error => console.error(error));   
    }

     //to Delete the selected Inventory detail from database.  
     deleteinventoryDetails(inventoryIDs: number) {  
        var headers = new Headers();  
        headers.append('Content-Type', 'application/json; charset=utf-8');  
        // this.http.delete(this.bseUrl + 'api/InventoryMasterAPI/' + inventoryIDs, { headers: headers }).subscribe(response => {  
        //     this.getData();  
  
        // }, error => {  
        // }  
        // );   
  
        //this.http.get(this.bseUrl + 'api/InventoryMasterAPI/Inventory').subscribe(result => {  
        //    this.Inventory = result.json();  
        //}, error => console.error(error));   
    }  
  
    closeEdits() {  
        this.AddTable = false;  
        // To stored Student Informations for insert/Update and Delete  
        this.sInventoryID = 0;  
        this.sItemName = "";  
        this.sStockQty = 50;  
        this.sReorderQty = 50;  
        this.sPriorityStatus = false;  
    } 

}

export interface InventoryMaster {  
    inventoryID: number;  
    itemName: string;  
    stockQty: number;  
    reorderQty: number;  
    priorityStatus: number;  
} 
