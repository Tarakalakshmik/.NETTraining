Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports MVC_DatabaseFirst

Namespace Controllers
    Public Class Shippers1Controller
        Inherits System.Web.Mvc.Controller

        Private db As New practiceEntities

        ' GET: Shippers1
        Function Index() As ActionResult
            Return View(db.Shippers.ToList())
        End Function

        ' GET: Shippers1/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim shipper As Shipper = db.Shippers.Find(id)
            If IsNothing(shipper) Then
                Return HttpNotFound()
            End If
            Return View(shipper)
        End Function

        ' GET: Shippers1/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Shippers1/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ShipperID,CompanyName,Phone")> ByVal shipper As Shipper) As ActionResult
            If ModelState.IsValid Then
                db.Shippers.Add(shipper)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(shipper)
        End Function

        ' GET: Shippers1/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim shipper As Shipper = db.Shippers.Find(id)
            If IsNothing(shipper) Then
                Return HttpNotFound()
            End If
            Return View(shipper)
        End Function

        ' POST: Shippers1/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ShipperID,CompanyName,Phone")> ByVal shipper As Shipper) As ActionResult
            If ModelState.IsValid Then
                db.Entry(shipper).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(shipper)
        End Function

        ' GET: Shippers1/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim shipper As Shipper = db.Shippers.Find(id)
            If IsNothing(shipper) Then
                Return HttpNotFound()
            End If
            Return View(shipper)
        End Function

        ' POST: Shippers1/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim shipper As Shipper = db.Shippers.Find(id)
            db.Shippers.Remove(shipper)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
