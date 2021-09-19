using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GenerateUnitEventTest
{
    class Program
    {
        static List<string> outdata = new List<string>( );
        static List<string> outdata2 = new List<string>( );

        static int sleepid = 0;

        static void PrintNextPlayerEventReg ( int id )
        {
            sleepid++;

            if ( sleepid > 500 )
            {
                sleepid = 0;
                outdata2.Add( "  call TriggerSleepAction(0.25)" );
            }

            outdata.Add( " " );
            outdata2.Add( "call InitTrig_notarget_" + id + "( ) " );
            outdata.Add( "function Trig_notarget_Actions_" + id + " takes nothing returns nothing" );
            outdata.Add( "call DisplayTimedTextToForce(GetPlayersAll(), 10.00, \"" + id + "\")" );
            outdata.Add( "endfunction" );
            outdata.Add( " " );

            outdata.Add( "function InitTrig_notarget_" + id + " takes nothing returns nothing" );
            outdata.Add( "  set TriggerName=CreateTrigger()" );
            outdata.Add( "  call TriggerRegisterAnyUnitEventBJ(TriggerName, ConvertPlayerUnitEvent(" + id + "))" );
            outdata.Add( "  call TriggerAddAction(TriggerName, function Trig_notarget_Actions_" + id + ")" );
            //  outdata.Add( "set tmp_notarget = null" );
            outdata.Add( "endfunction" );

/*

            outdata.Add( " " );
            outdata2.Add( "call InitTrig_x_notarget_" + id + "( ) " );
            outdata.Add( "function Trig_x_notarget_Actions_" + id + " takes nothing returns nothing" );
            outdata.Add( "call DisplayTimedTextToForce(GetPlayersAll(), 10.00, \"" + id + "\")" );
            outdata.Add( "endfunction" );
            outdata.Add( " " );

            outdata.Add( "function InitTrig_x_notarget_" + id + " takes nothing returns nothing" );
            outdata.Add( "  set TriggerName=CreateTrigger()" );
            outdata.Add( "  call TriggerRegisterGameEvent(TriggerName, ConvertGameEvent(" + id + "))" );
            outdata.Add( "  call TriggerAddAction(TriggerName, function Trig_x_notarget_Actions_" + id + ")" );
            //  outdata.Add( "set tmp_notarget = null" );
            outdata.Add( "endfunction" );*/
        }

        static void Main ( string [ ] args )
        {
            outdata2.Add( "function InitTrig_all_notargets takes nothing returns nothing" );

            for ( int i = 0 ; i < 500 ; i++ )
            {
                PrintNextPlayerEventReg( i );
            }
/*
            Random xrand = new Random( );
            for ( int i = 0 ; i < 50 ; i++ )
            {
                PrintNextPlayerEventReg( xrand.Next( 0 , 999999 ) );

            }*/
            PrintNextPlayerEventReg( 524896 );
            PrintNextPlayerEventReg( 524816 );
            PrintNextPlayerEventReg( 524800 );
        //    PrintNextPlayerEventReg( -524896 );
        //    PrintNextPlayerEventReg( -524816 );
        //    PrintNextPlayerEventReg( -524800 );


            outdata2.Add( "endfunction" );

            File.WriteAllLines( "outfile1.txt" , outdata.ToArray( ) );
            File.WriteAllLines( "outfile2.txt" , outdata2.ToArray( ) );

        }
    }
}
