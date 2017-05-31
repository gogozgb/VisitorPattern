using System;
using System.Collections.Generic;

namespace VisitorPattern
{
  public abstract class DocumentTypePart
  {
    public string TextToSave { get; set; }
    public abstract void Accept(Visitor visitor);
  }
  public class PDF : DocumentTypePart
  {
    public override void Accept(Visitor visitor)
    {
      visitor.Visit(this);
    }
  }
  public class DOC : DocumentTypePart
  {
    public override void Accept(Visitor visitor)
    {
      visitor.Visit(this);
    }
  }

  public class Documents
  {
    private List<DocumentTypePart> m_parts = new List<DocumentTypePart>();

    public void Add(DocumentTypePart part)
    {
      m_parts.Add(part);
    }

    public void Accept(Visitor visitor)
    {
      foreach (DocumentTypePart part in this.m_parts)
      {
        part.Accept(visitor);
      }
    }
  }
  public interface Visitor
  {
    void Visit(PDF txtPart);
    void Visit(DOC txtPart);
  }
  public class AddTextToDocumentVisitor : Visitor
  {
    public void Visit(PDF docPart)
    {
      Console.WriteLine("Dodajem text u PDF: " + docPart.TextToSave + "\n");
    }
    public void Visit(DOC docPart)
    {
      Console.WriteLine("Dodajem text u DOC: " + docPart.TextToSave + "\n");
    }
  }

  public class SaveDocument : Visitor
  {
    public void Visit(PDF docPart)
    {
      Console.WriteLine("Spremam u PDF...\n");
    }
    public void Visit(DOC docPart)
    {
      Console.WriteLine("Spremam u DOC...\n");
    }
  }
  class Program
  {
    static void Main(string[] args)
    {
      Documents document = new Documents();
      AddTextToDocumentVisitor AddTextVisitor = new AddTextToDocumentVisitor();
      Console.WriteLine("VISITOR PATTERN PRIMJER:\n");
      string str = "Neki tekst";
      document.Add(new DOC { TextToSave = str });
      document.Add(new PDF { TextToSave = str });
      document.Accept(AddTextVisitor);
      SaveDocument SaveDocumentVisitor = new SaveDocument();
      document.Accept(SaveDocumentVisitor);
    }
  }
}

